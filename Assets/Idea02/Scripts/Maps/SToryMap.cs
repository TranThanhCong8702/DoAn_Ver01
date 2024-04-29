using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SToryMap : MonoBehaviour
{
    [SerializeField] List<Gold> goldlist;

    private void OnEnable()
    {
        foreach (Gold gold in goldlist)
        {
            gold.gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        foreach(Gold gold in goldlist)
        {
            gold.gameObject.SetActive(false);  
            gold.isAdd = false;
        }
    }
}
