using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimulationMenuPage : MonoBehaviour, IMenuPage
{
    #region TimeScale
    [SerializeField] UnityEngine.UI.InputField time_scale;
    bool time_scale_was_changed = false;
    public float TimeScale
    {
        get
        {
            try
            {
                float result = float.Parse(time_scale.text.Replace('.', ','));
                return result;
            }
            catch
            {
                float default_time_scale = SettingsController.Instance.DefaultSettings.time_scale;
                time_scale.text = default_time_scale.ToString();
                return default_time_scale;
            }
        }
    }
    #endregion

    #region UIInteractions
    public void TimeScaleFieldEndEdit() => time_scale_was_changed = true;
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    #endregion;

    void ConfirmChanges()
    {
        if (time_scale_was_changed)
        {
            SettingsController.Instance.TimeScale = TimeScale;
            time_scale_was_changed = false;
        }
    }
    void ResetToDefault()
    {
        SettingsController.Instance.ResetSimulationMenu();
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
        time_scale.text = SettingsController.Instance.TimeScale.ToString();
        time_scale_was_changed = false;
    }
}
