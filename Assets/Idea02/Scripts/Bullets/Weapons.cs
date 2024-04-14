using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public int Damage = 1;
    [SerializeField] protected float WaitTime = 0.2f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float ingameScale = 0.2f;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Collider2D col;
    [SerializeField] protected ParticleSystem paticle;
    [SerializeField] protected AudioSource audioSource;
    public FixedJoint2D joint;
    [SerializeField] float maxSize = 5f;
    bool demFlag;

    protected void Start()
    {

    }

    private void FixedUpdate()
    {
        //if (transform.localScale.x < (Vector3.one * maxSize).x && transform.localScale.y < (Vector3.one * maxSize).y)
        //{
        //    transform.localScale += Vector3.one * Time.deltaTime;
        //}
    }

    protected void OnEnable()
    {
        transform.localScale = Vector3.one * ingameScale;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            col.isTrigger = true;
            joint.enabled = true;
            joint.connectedBody = collision.rigidbody;
            StartCoroutine(DelayEx());
        }
    }

    IEnumerator DelayEx()
    {
        yield return new WaitForSeconds(1f);
        Explode();
    }
    private void Explode()
    {
            spriteRenderer.enabled = false;
            if (audioSource != null)
            {
                audioSource.Play();
            }
            if (paticle)
            {
                paticle.Play();
            }
            col.enabled = false;
            StartCoroutine(ReturnPool());
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(WaitTime);
        ObjectPool.instance.Return(gameObject, true);
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = true;
        col.isTrigger = true;
        joint.enabled = false;
        joint.connectedBody = null ;
    }
}
