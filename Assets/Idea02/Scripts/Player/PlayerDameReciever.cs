using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReciever : MonoBehaviour
{
    [SerializeField] Playermanager managre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var t = collision.GetComponent<Weapons>();
        if (collision.CompareTag("Missile"))
        {
            if(managre && t)
            {
                managre.HpDes(t.Damage);
                Debug.Log("Being Damaged " + transform.name);
            }
        }
    }
}
