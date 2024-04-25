using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 1f;
    [SerializeField] float WaitDisApp = 1f;
    [SerializeField] Vector3 ScalePlat;
    public bool followX;
    public bool IsFirstPlat;
    [SerializeField] List<GameObject> attachment;
    Vector3 movingDir;

    private void Start()
    {
        if (followX)
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            //transform.position += new Vector3(0,speed * Time.deltaTime, 0);
            rb.velocity = new Vector2(0, speed);
        }

        transform.localScale = Vector3.zero + ScalePlat;
    }

    private void OnEnable()
    {
        if (followX)
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            //transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            rb.velocity = new Vector2(0, speed);
        }

        transform.localScale = Vector3.zero + ScalePlat;
    }
    private void FixedUpdate()
    {
        if (followX)
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            //transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            rb.velocity = new Vector2(0, speed);
        }

        transform.localScale = Vector3.zero + ScalePlat;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            if (IsFirstPlat)
            {
                speed = -speed;
            }
            //else
            //{
            //    StartCoroutine(ReturnPool());
            //}
        }
    }
    //IEnumerator ReturnPool()
    //{
    //    yield return new WaitForSeconds(WaitDisApp);
    //    ObjectPool.instance.Return(gameObject, true);
    //}
}
