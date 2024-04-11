using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public void ExitToMain()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
