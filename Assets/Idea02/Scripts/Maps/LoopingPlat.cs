using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingPlat : MonoBehaviour
{
    [SerializeField] float LoopSpeed = 5f;
    [SerializeField] Renderer ren;
    [SerializeField] Material mat;
    int count = 0;
    private void Findmet()
    {
        //if(count == 0)
        //{
        //}

    }
    // Update is called once per frame
    private void LateUpdate()
    {
        ren.material.mainTextureOffset += new Vector2(LoopSpeed * Time.deltaTime, 0f);
    }
    void change()
    {
        ren.material = mat;
    }
}
