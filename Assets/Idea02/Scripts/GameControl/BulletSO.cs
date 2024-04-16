using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletList", fileName = "Bullet")]
public class BulletSO : ScriptableObject
{
    public int BulletID = 0;
    public float Cost = 10;
    public bool IsBought;
    public Sprite avatar;
    public GameObject Bullets;
    [TextArea(2, 6)]
    public string Description;
    public string Name;
}
