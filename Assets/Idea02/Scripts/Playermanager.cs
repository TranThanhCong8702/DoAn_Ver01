using System.Collections;
using System.Collections.Generic;
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
    public float ManaBarmax = 10;
    public float ManaBarVal;
    float manaDem = 0;
    [SerializeField] float cooldownTime = 2f;

    private void Start()
    {
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
        ManaBarVal = ManaBarmax;
        ManaBar.fillAmount = ManaBarVal / ManaBarmax;
    }
    private void OnEnable()
    {
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
        ManaBarVal = ManaBarmax;
        ManaBar.fillAmount = ManaBarVal / ManaBarmax;
    }
    public void HpDes()
    {
        HPvalue -= 1;
        HPslider.fillAmount = HPvalue / HPmax;
    }
    public void ManaDes()
    {
        ManaBarVal-= 1;
        ManaBar.fillAmount = ManaBarVal/ManaBarmax;
    }
    private void Update()
    {
        if(ManaBarVal < ManaBarmax)
        {
            if(manaDem < cooldownTime)
            {
                manaDem += Time.deltaTime;
            }
            if(manaDem > cooldownTime)
            {
                ManaBarVal += 1;
                ManaBar.fillAmount = ManaBarVal / ManaBarmax;
                manaDem = 0;
            }
        }
        HpbarContainer.position = followTarget.position + new Vector3(0,1.5f,0);
    }
}
