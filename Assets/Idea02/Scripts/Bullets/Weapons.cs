using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public int Damage = 1;
    [SerializeField] protected float WaitTime = 0.2f;
    [SerializeField] protected float WaitTimeToEx = 0.2f;
    [SerializeField] float AppearTime = 5f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float ingameScale = 0.2f;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Collider2D col;
    [SerializeField] protected ParticleSystem paticle;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] Animator anim;
    public FixedJoint2D joint;
    [SerializeField] float maxSize = 5f;
    
    float appearTimebase = 0;

    public bool IsBought
    {
        get => PlayerPrefs.GetInt(transform.name, 0) == 1;
        set => PlayerPrefs.SetInt(transform.name, value ? 1 : 0);
    }

    protected void Start()
    {
        appearTimebase = AppearTime;
    }

    private void FixedUpdate()
    {
        //if (transform.localScale.x < (Vector3.one * maxSize).x && transform.localScale.y < (Vector3.one * maxSize).y)
        //{
        //    transform.localScale += Vector3.one * Time.deltaTime;
        //}
        if(AppearTime > 0 && col.enabled && !joint.enabled)
        {
            AppearTime -= Time.deltaTime;
            if(AppearTime <= 0)
            {
                StartCoroutine(DelayEx());
            }
        }
    }

    protected void OnEnable()
    {
        transform.localScale = Vector3.one * ingameScale;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.CompareTag("Bomb") && collision.isTrigger)
        //{
        //    Explode();
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            col.isTrigger = true;
            joint.enabled = true;
            joint.connectedBody = collision.rigidbody;
            joint.enableCollision = true;
            if (anim)
            {
                anim.enabled = true;
            }
            StartCoroutine(DelayEx());
        }
    }

    IEnumerator DelayEx()
    {
        yield return new WaitForSeconds(WaitTimeToEx);
        Explode();
    }
    public void Explode()
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
            //col.enabled = false;
            col.isTrigger = true;
            transform.localScale = Vector3.one * maxSize;
            transform.tag = "Missile";
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
        if (anim)
        {
            anim.enabled = false;
        }
        col.isTrigger = true;
        joint.enabled = false;
        joint.connectedBody = null ;
        transform.localScale = Vector3.one * ingameScale;
        transform.tag = "Bomb";
        AppearTime = appearTimebase;
    }
}
