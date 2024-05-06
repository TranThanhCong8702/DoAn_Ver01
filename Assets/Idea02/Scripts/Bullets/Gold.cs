using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public bool isAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isAdd)
            {
                Pref_Data.Gold++;
                SoundManager.instance.CoinSound(transform);
                isAdd = true;
            }
            UIController.instance.storuUI.gold.text = Pref_Data.Gold.ToString();
            gameObject.SetActive(false);
        }
    }
}
