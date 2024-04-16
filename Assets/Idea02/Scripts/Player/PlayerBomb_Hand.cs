using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb_Hand : MonoBehaviour
{
    [SerializeField] FixedJoint2D fix;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Playermanager playermanager;
    [SerializeField] float ThrowSpeed = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            //AttachBomd(collision);
        }

    }

    public void AttachBomd(Collider2D collision)
    {
        fix.enabled = true;
        fix.connectedBody = collision.attachedRigidbody;
        collision.enabled = false;
        //Debug.Log("Again");
    }

    public void Throw()
    {
        fix.enabled = false;
        fix.connectedBody.velocity = playermanager.move.moveVal * ThrowSpeed;
        Invoke("StartBombing", playermanager.waitToBombTime);
    }

    private void StartBombing()
    {
        fix.connectedBody.GetComponent<Collider2D>().enabled = true;
        fix.connectedBody.GetComponent<Collider2D>().isTrigger = false;
    }
}
