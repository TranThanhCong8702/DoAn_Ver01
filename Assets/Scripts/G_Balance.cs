using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Balance : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float targetRot = 0;
    [SerializeField] float force = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRot, force * Time.fixedDeltaTime));
    }
}
