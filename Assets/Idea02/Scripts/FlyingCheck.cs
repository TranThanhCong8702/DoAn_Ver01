using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FlyingCheck : MonoBehaviour
{
    public Movement2 move;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") && move.MouseIsUp)
        {
            //move.IsOnGround = true;
        }
    }
}
