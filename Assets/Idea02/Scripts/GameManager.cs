using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform GamePlay;
    public Camera cam;
    public LineRenderer _line;
    //public Movement2 playermove;
    //public Hooks hook;
    public List<BulletSO> bulletSOs;

    public List<GameObject> Maps;
    public List<GameObject> Players;

    private void Awake()
    {
        instance = this;
    }

    public void InsPvPmaps()
    {
        int i = Random.Range(0, Maps.Count);
        var t = Instantiate(Maps[i], GamePlay);
    }
    public void PlayerNumbOn(int number)
    {
        for(int i = 0; i < number; i++)
        {
            Players[i].SetActive(true);
        }
    }
    public void PlayerOff()
    {
        foreach(var p in Players)
        {
            p.SetActive(false);
        }
    }
    public void InsStorymaps()
    {

    }
}
