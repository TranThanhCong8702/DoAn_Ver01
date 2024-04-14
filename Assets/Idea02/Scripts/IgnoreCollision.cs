using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] List<Collider2D> colliders;
    void Start()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            for(int k = i + 1; k < colliders.Count; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }

}
