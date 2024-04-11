using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPUI : MonoBehaviour
{
    public void PlayPvp()
    {
        UIController.instance.inGameUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
