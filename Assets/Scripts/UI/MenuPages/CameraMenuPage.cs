using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuPage : MonoBehaviour, IMenuPage
{
    [SerializeField] UnityEngine.UI.Toggle crosshair_toggle;
    public bool CrosshairToggle
    {
        get => crosshair_toggle.isOn;
        set => crosshair_toggle.isOn = value;
    }

    public void ConfirmButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();

    public void LoadOnActivation()
    {
        CrosshairToggle = bool.Parse(SettingsController.Instance.OverallGetter("Crosshair").Item2);
    }
    public void ActivateGameObject()
    {
        gameObject.SetActive(true);
        LoadOnActivation();
    }
    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    void ConfirmChanges()
    {
        SettingsController.Instance.OverallSetter("Crosshair", CrosshairToggle.ToString());
    }
    void ResetToDefault() // Reset settings from DefaultSettings ScriptableObject
    {
        SettingsController.Instance.ResetCameraMenu();
        LoadOnActivation();
    }
}
