using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasedArrayGenerationMenuPage : MonoBehaviour, IMenuPage
{
    #region AntennasCount
    [SerializeField] UnityEngine.UI.InputField antennas_count;
    public int AntennasCount
    {
        get
        {
            try
            {
                int result = int.Parse(antennas_count.text.Replace('.', ','));
                return result;
            }
            catch
            {
                int default_antennas_count = SettingsController.Instance.DefaultSettings.antennas_count;
                antennas_count.text = default_antennas_count.ToString();
                return default_antennas_count;
            }
        }
    }
    bool antennas_count_was_changed = false;
    #endregion
    #region WaveLength
    [SerializeField] UnityEngine.UI.InputField wave_length;
    public double WaveLength
    {
        get
        {
            try
            {
                double result = double.Parse(wave_length.text.Replace('.', ','));
                return result;
            }
            catch
            {
                double default_wave_length = SettingsController.Instance.DefaultSettings.wave_length;
                wave_length.text = default_wave_length.ToString();
                return default_wave_length;
            }
        }
    }
    bool wave_length_was_changed = false;
    #endregion
    #region DistanceBetweenEmitters
    [SerializeField] UnityEngine.UI.InputField distance_between_emitters;
    public double DistanceBetweenEmitters
    {
        get
        {
            try
            {
                double result = double.Parse(distance_between_emitters.text.Replace('.', ','));
                return result;
            }
            catch
            {
                double default_distance = SettingsController.Instance.DefaultSettings.distance_between_emitters;
                distance_between_emitters.text = default_distance.ToString();
                return default_distance;
            }
        }
    }
    bool distance_between_emitters_was_changed = false;
    #endregion

    #region UIInteractions
    public void AntennasCountEndEdit() => antennas_count_was_changed = true;
    public void WaveLengthEndEdit() => wave_length_was_changed = true;
    public void DistanceBetweenEmittersEndEdit() => distance_between_emitters_was_changed = true;
    public void ResetToDefaultButtonPressed() => ResetToDefault();
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    #endregion

    void ResetToDefault()
    {
        SettingsController.Instance.ResetPhasedArrayGenerationPage();
        LoadOnActivation();
    }
    void ConfirmChanges()
    {
        if (antennas_count_was_changed)
        {
            SettingsController.Instance.AntennasCount = AntennasCount;
            antennas_count_was_changed = false;
        }
        if (wave_length_was_changed)
        {
            SettingsController.Instance.WaveLength = WaveLength;
            wave_length_was_changed = false;
        }
        if (distance_between_emitters_was_changed)
        {
            SettingsController.Instance.DistanceBetweenEmitters = DistanceBetweenEmitters;
            distance_between_emitters_was_changed = false;
        }
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
        antennas_count.text = SettingsController.Instance.AntennasCount.ToString();
        wave_length.text = SettingsController.Instance.WaveLength.ToString();
        distance_between_emitters.text = SettingsController.Instance.DistanceBetweenEmitters.ToString();

        antennas_count_was_changed = false;
        wave_length_was_changed = false;
        distance_between_emitters_was_changed = false;
    }
}
