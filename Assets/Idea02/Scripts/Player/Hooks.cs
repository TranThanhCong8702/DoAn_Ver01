using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooks : MonoBehaviour
{
    public Collider2D coll;
    [SerializeField] SpringJoint2D joint;
    [SerializeField] FixedJoint2D Fixjoint;
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
            //rb.bodyType = RigidbodyType2D.Static;
            Fixjoint.enabled = true;
            Fixjoint.connectedBody = collision.attachedRigidbody;
            joint.enabled = true;
        }
    }
    public void DisableJoint()
    {
        //rb.bodyType = RigidbodyType2D.Dynamic;
        Fixjoint.enabled = false;
        Fixjoint.connectedBody = null;
        joint.enabled = false;
        coll.enabled = false;
    }
    //private void Update()
    //{
    //    if (Fixjoint.enabled && joint.enabled)
    //    {
    //        joint.connectedBody.MovePosition(new Vector2(joint.connectedBody.transform.position.x, transform.position.y - 2));
    //    }
    //}
}
