using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public MainUI mainUI;
    public InGameUI inGameUI;
    public ShopUI shopUI;
    public PvPUI pvPUI;
    public UISetting settingUI;
    public LevelListUI levelListUI;
    public InGameStory storuUI;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        //settingUI.GetRebindWhenEnabled();
    }
}
