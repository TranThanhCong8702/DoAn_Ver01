using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameStory : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    public Text gold;
    public GameObject WinPopUp;
    public Text winner;

    private void OnEnable()
    {
        gold.text = Pref_Data.Gold.ToString();
    }

    public void Pause()
    {
        GameManager.instance.StopTime();
        PopUp.SetActive(true);
        SoundManager.instance.volumeSlider3.value = Pref_Data.Sound;
    }
    public void ExitToMain()
    {
        GameManager.instance.DesStoryMap();
        GameManager.instance.AllPlayerOff();
        UIController.instance.mainUI.gameObject.SetActive(true);
        PopUp.SetActive(false);
        WinPopUp.SetActive(false);
        gameObject.SetActive(false);
        GameManager.instance.ChangeCamBack();
    }

    public void Resume()
    {
        GameManager.instance.StartTime();
        PopUp.SetActive(false);
    }
}
