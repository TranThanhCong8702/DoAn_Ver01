using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref_Data
{
    public static float Sound
    {
        get => PlayerPrefs.GetFloat("sound", 1);
        set => PlayerPrefs.SetFloat("sound", value);
    }

    public static int BombID
    {
        get => PlayerPrefs.GetInt("bombID", 0);
        set => PlayerPrefs.SetInt("bombID", value);
    }
}
