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
            move.IsFlying = true;
        }
    }
    public void DisableJoint()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        joint.enabled = false;
        coll.enabled = false;
    }
    private void OnDisable()
    {
        if(move.Hip.velocity.y < 0.2f)
        {
            move.IsFlying = false;
        }
    }
}
