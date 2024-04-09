using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReciever : MonoBehaviour
{
    [SerializeField] Playermanager managre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            if(managre)
            {
                managre.HpDes();
            }
        }
    }
}
