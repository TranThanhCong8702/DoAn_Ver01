using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    
    public void Setting()
    {
        UIController.instance.settingUI.gameObject.SetActive(false);
        UIController.instance.settingUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Shop()
    {
        UIController.instance.settingUI.gameObject.SetActive(false);
        UIController.instance.shopUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Pvp()
    {
        UIController.instance.settingUI.gameObject.SetActive(false);
        UIController.instance.pvPUI.gameObject.SetActive(true);
        //UIController.instance.inGameUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void StoryMode()
    {
        UIController.instance.settingUI.gameObject.SetActive(false);
        UIController.instance.levelListUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
