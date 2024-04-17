using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPUI : MonoBehaviour
{
    [SerializeField] GameObject Player3Map;
    [SerializeField] Button Play;
    public void PlayPvp()
    {
        UIController.instance.inGameUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        Player3Map.SetActive(false);
    }
    public void BackMain()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        Player3Map.SetActive(false);
    }

}
