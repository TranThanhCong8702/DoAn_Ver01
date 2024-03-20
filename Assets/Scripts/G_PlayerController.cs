using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_PlayerController : MonoBehaviour
{
    [SerializeField] List<Collider2D> colliders;
    void Start()
    {
        for(int i = 0; i < colliders.Count; i++)
        {
            for(int j = i+1;  j < colliders.Count; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
