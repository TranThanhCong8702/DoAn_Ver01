using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = Pref_Data.Sound;
    }
    public void ChangeValue()
    {
        AudioListener.volume = volumeSlider.value;
        Pref_Data.Sound = volumeSlider.value;
    }
}
