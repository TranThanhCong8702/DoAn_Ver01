using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListUI : MonoBehaviour
{
    
    int currId = 0;

    public void InsStoryMap(int id)
    {
        GameManager.instance.StartTime();
        GameManager.instance.InsStorymaps(id);
        gameObject.SetActive(false);
    }
    public void ExitToMain()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
