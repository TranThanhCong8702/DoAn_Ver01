using UnityEngine;
using UnityEngine.InputSystem;

public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;
    public InputActionAsset actions1;
    public InputActionAsset actions2;

    public void OnEnable()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        var rebinds1 = PlayerPrefs.GetString("rebinds1");
        var rebinds2 = PlayerPrefs.GetString("rebinds2");
        if (!string.IsNullOrEmpty(rebinds))
            actions.LoadBindingOverridesFromJson(rebinds);
        if (!string.IsNullOrEmpty(rebinds1))
            actions1.LoadBindingOverridesFromJson(rebinds1);
        if (!string.IsNullOrEmpty(rebinds2))
            actions2.LoadBindingOverridesFromJson(rebinds2);
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        var rebinds1 = actions1.SaveBindingOverridesAsJson();
        var rebinds2 = actions2.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
        PlayerPrefs.SetString("rebinds1", rebinds1);
        PlayerPrefs.SetString("rebinds2", rebinds2);
    }
}
