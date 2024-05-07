using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListUI : MonoBehaviour
{

    public void InsStoryMap(int id)
    {
        GameManager.instance.StartTime();
        GameManager.instance.InsStorymaps(id);
        gameObject.SetActive(false);
        UIController.instance.storuUI.gameObject.SetActive(true);
        SoundManager.instance.SoundMainOff();
    }
    public void ExitToMain()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
