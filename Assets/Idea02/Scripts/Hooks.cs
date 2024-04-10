using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooks : MonoBehaviour
{
    public Collider2D coll;
    [SerializeField] SpringJoint2D joint;
    public Rigidbody2D rb;
    public float speed;
    public Movement2 move;
    public float length = 20;
    private void OnEnable()
    {
        coll.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            joint.enabled = true;
        }
    }
    public void DisableJoint()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        joint.enabled = false;
        coll.enabled = false;
    }

}
