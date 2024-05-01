using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReciever : MonoBehaviour
{
    [SerializeField] Playermanager managre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            managre.HpDes(50);
        }
        if (collision.CompareTag("traps") || collision.CompareTag("Enemy"))
        {
            managre.HpDes(2);
        }
        if (collision.CompareTag("Missile"))
        {
            var t = collision.GetComponent<Weapons>();
            if (managre && t)
            {
                managre.HpDes(t.Damage);
                Debug.Log("Being Damaged " + transform.name);
                collision.enabled = false;
            }
        }
    }
}
