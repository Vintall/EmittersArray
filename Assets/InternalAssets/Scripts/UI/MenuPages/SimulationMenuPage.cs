using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimulationMenuPage : MonoBehaviour, IMenuPage
{
    #region TimeScale
    [SerializeField] UnityEngine.UI.InputField time_scale;
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
                float default_time_scale = float.Parse(SettingsController.Instance.DefaultSettings.SettingsDictionary["time_scale"].Item2);
                time_scale.text = default_time_scale.ToString();
                return default_time_scale;
            }
        }
    }
    #endregion

    #region UIInteractions
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    #endregion;

    void ConfirmChanges()
    {
        SettingsController.Instance.OverallSetter("Time Scale", TimeScale.ToString());
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
        time_scale.text = SettingsController.Instance.OverallGetter("Time Scale").Item2;
    }
}
