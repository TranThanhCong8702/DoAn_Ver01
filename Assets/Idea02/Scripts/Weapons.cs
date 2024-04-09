using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float WaitTime = 0.2f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] float ingameScale = 0.2f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Collider2D col;
    [SerializeField] ParticleSystem paticle;
    [SerializeField] AudioSource audioSource;

    protected void Start()
    {
        transform.localScale = Vector3.one * ingameScale;
        rb.AddForce(/*new Vector2(speed, 0)*/transform.right * speed);
        if(rb.velocity.x < 0.5f || rb.velocity.y < 0.5f)
        {
            ObjectPool.instance.Return(gameObject, true);
        }
    }
    protected void OnEnable()
    {
        transform.localScale = Vector3.one * ingameScale;
        rb.AddForce(/*new Vector2(speed, 0)*/transform.right * speed);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Missile"))
        {
            rb.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            if(audioSource != null)
            {
                audioSource.Play();
            }
            paticle.Play();
            col.enabled = false;
            StartCoroutine(ReturnPool());
        }
    }
    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(WaitTime);
        ObjectPool.instance.Return(gameObject, true);
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = true;
        col.enabled = true;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
