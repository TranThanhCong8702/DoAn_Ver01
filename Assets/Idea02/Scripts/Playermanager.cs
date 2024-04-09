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

    private void Start()
    {
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
    }
    private void OnEnable()
    {
        HPvalue = HPmax;
        HPslider.fillAmount = HPvalue / HPmax;
    }
    public void HpDes()
    {
        HPvalue -= 1;
        HPslider.fillAmount = HPvalue / HPmax;
    }
    private void Update()
    {
        HpbarContainer.position = followTarget.position + new Vector3(0,1.5f,0);
    }
}
