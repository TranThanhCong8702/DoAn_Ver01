using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSapwner : MonoBehaviour
{
    [SerializeField] Movement2 move;
    [SerializeField] Playermanager playermanager;

    public void Shooting()
    {
        Debug.Log(Pref_Data.BombID);
        GameObject bullet = ObjectPool.instance.Get(ObjectPool.instance.pools[Pref_Data.BombID]);
        bullet.transform.position = transform.position;
        //bullet.transform.localScale = Vector3.one * 0.5f;
        bullet.SetActive(true);
        playermanager.hand.AttachBomd(bullet.GetComponent<Collider2D>());
    }
    //private void OnEnable()
    //{
    //    Shooting();
    //}
}