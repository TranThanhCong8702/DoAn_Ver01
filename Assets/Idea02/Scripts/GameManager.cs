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

    private void Awake()
    {
        instance = this;
    }
}
