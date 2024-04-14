using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playermanager : MonoBehaviour
{
    [Header("HpBar Follow")]
    [SerializeField] Transform HpbarContainer;
    [SerializeField] Transform followTarget;
    [Header("HpBar Control")]
    [SerializeField] Image HPslider;
    public float HPvalue;
    public float HPmax = 10;
    [SerializeField] Image ManaBar;
    public float ManaBarmax = 1f;
    public float ManaBarVal;
    [Header("Other")]
    public BulletSapwner bulletspawner;
    public Movement2 move;
    public PlayerBomb_Hand hand;
    public float waitToBombTime = 0.2f;

    private void Start()
    {
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
        ManaBarVal = ManaBarmax;
        ManaBar.fillAmount = ManaBarVal / ManaBarmax;
    }
    private void OnEnable()
    {
        Invoke("FirstBomb", 0.2f);
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
        ManaBarVal = ManaBarmax;
        ManaBar.fillAmount = ManaBarVal / ManaBarmax;
    }
    void FirstBomb()
    {
        bulletspawner.Shooting();
    }
    public void HpDes(int dame)
    {
        HPvalue -= dame;
        HPslider.fillAmount = HPvalue / HPmax;
    }

    private void Update()
    {
        if (ManaBarVal <= ManaBarmax && !move.hasBomb)
        {
            ManaBar.fillAmount = ManaBarVal / ManaBarmax;
            ManaBarVal += Time.deltaTime;
            if(ManaBarVal >= ManaBarmax)
            {
                bulletspawner.Shooting();
                move.hasBomb = true;
            }
        }
        HpbarContainer.position = followTarget.position + new Vector3(0,1.5f,0);
    }
}
