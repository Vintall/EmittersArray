using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    static SettingsMenu instance;
    [SerializeField] UnityEngine.UI.Toggle precise_plane_toggle;
    [SerializeField] UnityEngine.UI.Text frequency_min_value_label;
    [SerializeField] UnityEngine.UI.Text frequency_max_value_label;
    [SerializeField] UnityEngine.UI.Text frequency_cur_value_label;
    [SerializeField] UnityEngine.UI.Slider frequency_slider;
    public static SettingsMenu Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        frequency_min_value_label.text = frequency_slider.minValue.ToString();
        frequency_max_value_label.text = frequency_slider.maxValue.ToString();
        frequency_cur_value_label.text = frequency_slider.value.ToString();
    }
    public void PrecisePlaneToggleChanged()
    {
        GameController.Instance.PrecisePlaneStateChange(precise_plane_toggle.isOn);
    }
    public void FrequencySliderValueChanged()
    {
        SimulationController.Instance.WaveFrequency = frequency_slider.value;
        frequency_cur_value_label.text = frequency_slider.value.ToString();
    }
}
