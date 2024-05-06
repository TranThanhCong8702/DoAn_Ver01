using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Slider volumeSlider;
    public Slider volumeSlider2;
    public Slider volumeSlider3;

    [SerializeField] AudioClip coinsound;

    public void CoinSound(Transform coin)
    {
        AudioSource.PlayClipAtPoint(coinsound, coin.position);
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        volumeSlider.value = Pref_Data.Sound;
    }
    public void ChangeValue()
    {
        AudioListener.volume = volumeSlider.value;
        Pref_Data.Sound = volumeSlider.value;
        volumeSlider2.value = Pref_Data.Sound;
        volumeSlider3.value = Pref_Data.Sound;
    }
    public void ChangeValue2()
    {
        AudioListener.volume = volumeSlider2.value;
        Pref_Data.Sound = volumeSlider2.value;
        volumeSlider.value = Pref_Data.Sound;
        volumeSlider3.value = Pref_Data.Sound;
    }
    public void ChangeValue3()
    {
        AudioListener.volume = volumeSlider3.value;
        Pref_Data.Sound = volumeSlider3.value;
        volumeSlider.value = Pref_Data.Sound;
        volumeSlider2.value = Pref_Data.Sound;
    }
}
