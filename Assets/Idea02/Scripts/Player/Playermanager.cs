using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playermanager : MonoBehaviour
{
    [Header("Player Name")]
    public string playerName;
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
    public Vector3 DefaultPos;
    [SerializeField] float DeadTimer = 0.5f;
    [SerializeField] List<HingeJoint2D> joints;
    int dem = 0;
    private void Start()
    {
        DefaultPos = transform.position;
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
        ManaBarVal = ManaBarmax;
        ManaBar.fillAmount = ManaBarVal / ManaBarmax;
    }
    private void OnDisable()
    {
        //transform.position = DefaultPos;
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
        if(HPvalue <= 0 && dem == 0)
        {
            move.IsCCed = true;
            SelfDes();
            hand.OnExplode();
        }
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
    public void SelfDes()
    {
        dem++;
        foreach(var item in joints)
        {
            item.breakForce = 0;
        }
        if(GameManager.instance.IsPvp)
        {
            GameManager.instance.OnePlayerOffPvp();
        }
        else
        {

        }
        Destroy(gameObject, DeadTimer);
    }
    public void SelfDesImadiate()
    {
        Destroy(gameObject);
    }
}
