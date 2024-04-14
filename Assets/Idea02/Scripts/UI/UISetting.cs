using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class UISetting : MonoBehaviour
{
    //public List<InputActionReference> MoveRef;
    private void Start()
    {
        
    }
    public void Back()
    {
        UIController.instance.mainUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        //foreach (var action in MoveRef)
        //{
        //    action.action.Disable();
        //}
    }
    private void OnDisable()
    {
        //foreach (var action in MoveRef)
        //{
        //    action.action.Enable();
        //}
    }
    //[Header("Rebinding Keys")]
    //public InputActionAsset actions;
    //public void GetRebindWhenEnabled()
    //{
    //    var rebinds = PlayerPrefs.GetString("rebinds");
    //    if (!string.IsNullOrEmpty(rebinds))
    //        actions.LoadBindingOverridesFromJson(rebinds);
    //    Debug.Log("Getting");
    //}

    //public void SaveTheChangeKeys()
    //{
    //    var rebinds = actions.SaveBindingOverridesAsJson();
    //    PlayerPrefs.SetString("rebinds", rebinds);
    //}
}
