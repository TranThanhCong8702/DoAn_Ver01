using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    public GameObject WinPopUp;
    public Text winner;
    public void Pause()
    {
        GameManager.instance.StopTime();
        PopUp.SetActive(true);
        SoundManager.instance.volumeSlider2.value = Pref_Data.Sound;
    }
    public void ExitToMain()
    {
        GameManager.instance.DestroyMap();
        GameManager.instance.AllPlayerOff();
        UIController.instance.mainUI.gameObject.SetActive(true);
        PopUp.SetActive(false);
        WinPopUp.SetActive(false);
        gameObject.SetActive(false);
        SoundManager.instance.SoundMainOn();
    }
    public void PlayAgain()
    {
        GameManager.instance.DestroyMap();
        GameManager.instance.AllPlayerOff();
        WinPopUp.SetActive(false);
        UIController.instance.pvPUI.PlayPvp();
    }
    public void Resume()
    {
        GameManager.instance.StartTime();
        PopUp.SetActive(false);
    }
}
