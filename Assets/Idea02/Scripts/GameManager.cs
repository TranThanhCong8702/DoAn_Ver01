using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Camera cam;
    public LineRenderer _line;
    //public Movement2 playermove;
    //public Hooks hook;
    public GameObject PlayerPrefab;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        float t = Random.Range(-2, 2);
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(t, 0, 0), Quaternion.identity, 0);
        cam.gameObject.SetActive(false);
        _line.gameObject.SetActive(false);
    }
}
