using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsCape_Door : MonoBehaviour
{
    bool first;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !first)
        {
            GameManager.instance.Escape();
            first = true;
        }
    }
    private void OnDisable()
    {
        first = false;
    }
}
