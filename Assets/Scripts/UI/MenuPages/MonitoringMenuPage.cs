using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoringMenuPage : MonoBehaviour, IMenuPage
{
    #region EmittersCount
    [SerializeField] UnityEngine.UI.Toggle emitters_count;
    public bool EmittersCount
    {
        get => emitters_count.isOn;
        set => emitters_count.isOn = value;
    }    
    #endregion
    #region MaxEmitting
    [SerializeField] UnityEngine.UI.Toggle max_emitting;
    public bool MaxEmitting
    {
        get => max_emitting.isOn;
        set => max_emitting.isOn = value;
    }
    #endregion
    #region MinEmitting
    [SerializeField] UnityEngine.UI.Toggle min_emitting;
    public bool MinEmitting
    {
        get => min_emitting.isOn;
        set => min_emitting.isOn = value;
    }
    #endregion
    #region EmittingOnCrosshair
    [SerializeField] UnityEngine.UI.Toggle emitting_on_crosshair;
    public bool EmittingOnCrosshair
    {
        get => emitting_on_crosshair.isOn;
        set => emitting_on_crosshair.isOn = value;
    }
    #endregion

    #region UIInteractions
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    #endregion;

    void ConfirmChanges()
    {
        SettingsController.Instance.OverallSetter("Monitoring Emitters Count", EmittersCount.ToString());
        SettingsController.Instance.OverallSetter("Monitoring Max Emitting", MaxEmitting.ToString());
        SettingsController.Instance.OverallSetter("Monitoring Min Emitting", MinEmitting.ToString());
        SettingsController.Instance.OverallSetter("Monitoring Emitting On Crosshair", EmittingOnCrosshair.ToString());
    }
    void ResetToDefault()
    {
        SettingsController.Instance.ResetMonitoringPage();
        LoadOnActivation();
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

    public void LoadOnActivation()
    {
        EmittersCount = bool.Parse(SettingsController.Instance.OverallGetter("Monitoring Emitters Count").Item2);
        EmittingOnCrosshair = bool.Parse(SettingsController.Instance.OverallGetter("Monitoring Emitting On Crosshair").Item2);
        MinEmitting = bool.Parse(SettingsController.Instance.OverallGetter("Monitoring Min Emitting").Item2);
        MaxEmitting = bool.Parse(SettingsController.Instance.OverallGetter("Monitoring Max Emitting").Item2);
    }
}
