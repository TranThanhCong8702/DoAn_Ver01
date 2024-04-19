using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPUI : MonoBehaviour
{
    [SerializeField] GameObject Player3Map;
    [SerializeField] Button Play;
    int PlayerNumberPvP = 2;
    public void PlayPvp()
    {
        GameManager.instance.InsPvPmaps();
        GameManager.instance.PlayerNumbOn(PlayerNumberPvP);
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
    public void InsPlayerPvp(int numb)
    {
        if(numb == 2)
        {
            Player3Map.SetActive(false);

            PlayerNumberPvP = numb;
            Play.gameObject.SetActive(true);

        }
        else if(numb == 3)
        {
            Player3Map.SetActive(true);

            PlayerNumberPvP = numb;
            Play.gameObject.SetActive(true);
        }
    }
}
