using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Text BombName;
    [SerializeField] Text Des;
    [SerializeField] Text NotEnough;
    [SerializeField] Button Buy;
    [SerializeField] Button Equip;

    public Text gold;

    int currId =0;

    private void OnEnable()
    {
        ShowBomb(Pref_Data.BombID);
        gold.text = Pref_Data.Gold.ToString();
    }

    public void ShowBomb(int id)
    {
        NotEnough.gameObject.SetActive(false);
        currId = id;
        BombName.text = GameManager.instance.bulletSOs[id].Name;
        Des.text = GameManager.instance.bulletSOs[id].Description;
        if (!GameManager.instance.bulletSOs[currId].weapon.IsBought)
        {
            Buy.gameObject.SetActive(true);
            Buy.GetComponentInChildren<Text>().text ="Buy: " + GameManager.instance.bulletSOs[id].Cost.ToString();
            Equip.gameObject.SetActive(false);
        }
        else if(Pref_Data.BombID != id)
        {
            Buy.gameObject.SetActive(false);
            Equip.gameObject.SetActive(true);
        }
        else
        {
            Buy.gameObject.SetActive(false);
            Equip.gameObject.SetActive(false);
        }
    }

    public void Equiping()
    {
        Pref_Data.BombID = currId;
        Equip.gameObject.SetActive(false);
        Debug.Log(currId);
        Debug.Log(Pref_Data.BombID);
    }

    public void Buying()
    {
        if(Pref_Data.Gold >= GameManager.instance.bulletSOs[currId].Cost)
        {
            Pref_Data.Gold -= (int)GameManager.instance.bulletSOs[currId].Cost;
            GameManager.instance.bulletSOs[currId].weapon.IsBought = true;
            gold.text = Pref_Data.Gold.ToString();
            Equip.gameObject.SetActive(true);
            Buy.gameObject.SetActive(false);
        }
        else
        {
            NotEnough.gameObject.SetActive(true);
        }
    }

    public void ExitToMain()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
