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
    [SerializeField] FlexibleColorPicker color_picker;
    [SerializeField] UnityEngine.UI.Dropdown color_picker_dropdown;

    
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
    public void ColorPickerDropdownValueChanged()
    {
        if(color_picker_dropdown.value == 0)
        {
            color_picker.color = GameController.Instance.interferense_plane_material.GetColor("_Max_amplitude_color");
        }
        else
        {
            color_picker.color = GameController.Instance.interferense_plane_material.GetColor("_Min_amplitude_color");
        }
    }
    public void ColorPickerColorChanged()
    {
        if (GameController.Instance.interferense_plane_material == null)
            return;

        if (color_picker_dropdown.value == 0)
        {
            GameController.Instance.interferense_plane_material.SetColor("_Max_amplitude_color", color_picker.color);
        }
        else
        {
            GameController.Instance.interferense_plane_material.SetColor("_Min_amplitude_color", color_picker.color);
        }
    }
}
