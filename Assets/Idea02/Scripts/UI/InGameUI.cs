using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public void ExitToMain()
    {
        GameManager.instance.DestroyMap();
        GameManager.instance.AllPlayerOff();
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
