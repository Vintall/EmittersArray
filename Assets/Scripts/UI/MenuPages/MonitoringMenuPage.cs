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
    bool emitters_count_was_changed = false;
    #endregion
    #region MaxEmitting
    [SerializeField] UnityEngine.UI.Toggle max_emitting;
    public bool MaxEmitting
    {
        get => max_emitting.isOn;
        set => max_emitting.isOn = value;
    }
    bool max_emitting_was_changed = false;
    #endregion
    #region MinEmitting
    [SerializeField] UnityEngine.UI.Toggle min_emitting;
    public bool MinEmitting
    {
        get => min_emitting.isOn;
        set => min_emitting.isOn = value;
    }
    bool min_emitting_was_changed = false;
    #endregion
    #region EmittingOnCrosshair
    [SerializeField] UnityEngine.UI.Toggle emitting_on_crosshair;
    public bool EmittingOnCrosshair
    {
        get => emitting_on_crosshair.isOn;
        set => emitting_on_crosshair.isOn = value;
    }
    bool emitting_on_crosshair_was_changed = false;
    #endregion

    #region UIInteractions
    public void EmittersCountTogglePressed() => emitters_count_was_changed = true;
    public void MaxEmittingTogglePressed() => max_emitting_was_changed = true;
    public void MinEmittingTogglePressed() => min_emitting_was_changed = true;
    public void EmittingOnCrosshairTogglePressed() => emitting_on_crosshair_was_changed = true;
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    #endregion;

    void ConfirmChanges()
    {
        if (emitters_count_was_changed)
        {
            SettingsController.Instance.MonitoringEmittersCount = EmittersCount;
            emitters_count_was_changed = false;
        }

        if (max_emitting_was_changed)
        {
            SettingsController.Instance.MonitoringMaxEmitting = MaxEmitting;
            max_emitting_was_changed = false;
        }

        if (min_emitting_was_changed)
        {
            SettingsController.Instance.MonitoringMinEmitting = MinEmitting;
            min_emitting_was_changed = false;
        }

        if (emitting_on_crosshair_was_changed)
        {
            SettingsController.Instance.MonitoringEmittingOnCrosshair = EmittingOnCrosshair;
            emitting_on_crosshair_was_changed = false;
        }
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
        emitters_count_was_changed = false;
        max_emitting_was_changed = false;
        min_emitting_was_changed = false;
        emitting_on_crosshair_was_changed = false;

        EmittersCount = SettingsController.Instance.MonitoringEmittersCount;
        EmittingOnCrosshair = SettingsController.Instance.MonitoringEmittingOnCrosshair;
        MinEmitting = SettingsController.Instance.MonitoringMinEmitting;
        MaxEmitting = SettingsController.Instance.MonitoringMaxEmitting;
    }
}
