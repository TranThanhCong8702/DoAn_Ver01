using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSapwner : MonoBehaviour
{
    [SerializeField] Movement2 move;
    //void Start()
    //{
    //    StartCoroutine(Shoot());
    //}
    //IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(FireRate);
    //        if (move.IsShooting)
    //        {
    //            var bullet = ObjectPool.instance.Get(ObjectPool.instance.bullet);
    //            bullet.transform.position = transform.position;
    //            bullet.transform.rotation = transform.parent.rotation;
    //            //bullet.transform.localScale = Vector3.one * 0.5f;
    //            bullet.SetActive(true);
    //        }
    //    }
    //}

    public void Shooting()
    {
        var bullet = ObjectPool.instance.Get(ObjectPool.instance.bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.parent.rotation;
        //bullet.transform.localScale = Vector3.one * 0.5f;
        bullet.SetActive(true);
    }
}
