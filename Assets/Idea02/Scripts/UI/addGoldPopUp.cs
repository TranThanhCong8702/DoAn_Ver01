using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addGoldPopUp : MonoBehaviour
{
    public void addGoldpopOn()
    {
        gameObject.SetActive(true);
        StartCoroutine(addGoldpopOff());
    }
    IEnumerator addGoldpopOff()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
