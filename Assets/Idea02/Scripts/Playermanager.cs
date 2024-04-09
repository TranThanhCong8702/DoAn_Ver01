using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermanager : MonoBehaviour
{
    [SerializeField] Slider HPslider;
    [SerializeField] float HPvalue;
    [SerializeField] float HPmax = 10;

    private void Start()
    {
        HPvalue = HPmax;
        HPslider.value = HPvalue;
        HPslider.maxValue = HPmax;
    }
    private void OnEnable()
    {
        HPvalue = HPmax;
        HPslider.value = HPvalue;
        HPslider.maxValue = HPmax;
    }
    public void HpDes()
    {
        HPvalue -= 1;
        HPslider.value = HPvalue;
    }
}
