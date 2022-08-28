using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuPage : MonoBehaviour, IMenuPage
{
    #region FreeCamToggle
    [SerializeField] UnityEngine.UI.Toggle free_cam_toggle;
    public bool FreeCamToggle
    {
        get => free_cam_toggle.isOn;
        set => free_cam_toggle.isOn = value;
    }
    bool free_cam_was_changed = false;
    #endregion
    #region CrossgairToggle
    [SerializeField] UnityEngine.UI.Toggle crosshair_toggle;
    public bool CrosshairToggle
    {
        get => crosshair_toggle.isOn;
        set => crosshair_toggle.isOn = value;
    }
    bool crosshair_was_changed = false;
    #endregion

    #region UIInteractions
    public void FreeCamTogglePressed() => free_cam_was_changed = true;
    public void CrosshairTogglePressed() => crosshair_was_changed = true;
    public void ConfirmButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    #endregion

    public void LoadOnActivation()
    {
        FreeCamToggle = SettingsController.Instance.FreeCam;
        CrosshairToggle = SettingsController.Instance.Crosshair;

        crosshair_was_changed = false;
        free_cam_was_changed = false;
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
        if (crosshair_was_changed)
        {
            SettingsController.Instance.Crosshair = CrosshairToggle;
            crosshair_was_changed = false;
        }
        if (free_cam_was_changed)
        {
            SettingsController.Instance.FreeCam = FreeCamToggle;
            free_cam_was_changed = false;
        }
    }
    void ResetToDefault() // Reset settings from DefaultSettings ScriptableObject
    {
        SettingsController.Instance.ResetCameraMenu();
        LoadOnActivation();
    }
}
