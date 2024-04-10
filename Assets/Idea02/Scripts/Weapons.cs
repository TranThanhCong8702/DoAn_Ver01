using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float WaitTime = 0.2f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float ingameScale = 0.2f;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Collider2D col;
    [SerializeField] protected ParticleSystem paticle;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] float maxSize = 5f;
    bool demFlag;

    protected void Start()
    {
        transform.localScale = Vector3.one * ingameScale;
        rb.AddForce(/*new Vector2(speed, 0)*/transform.right * speed);
        if (rb.velocity.x < 0.5f || rb.velocity.y < 0.5f)
        {
            //ObjectPool.instance.Return(gameObject, true);
            rb.AddForce(/*new Vector2(speed, 0)*/transform.right * speed);
        }
    }

    private void FixedUpdate()
    {
        if (transform.localScale.x < (Vector3.one * maxSize).x && transform.localScale.y < (Vector3.one * maxSize).y)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
    }

    protected void OnEnable()
    {
        transform.localScale = Vector3.one * ingameScale;
        rb.AddForce(/*new Vector2(speed, 0)*/transform.right * speed);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            Explode();
        }
        else if (collision.transform.CompareTag("Missile"))
        {
            if(rb.velocity == Vector2.zero && !demFlag)
            {
                demFlag = true;
                rb.velocity = collision.attachedRigidbody.velocity;
                StartCoroutine(DelayEx());
            }
            else
            {
                Explode();
            }

        }
        else if (collision.transform.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
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
        col.enabled = true;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        demFlag = false;
    }
}
