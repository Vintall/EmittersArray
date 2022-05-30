using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationControllerMenu : MonoBehaviour
{
    static SimulationControllerMenu instance;

    [SerializeField] UnityEngine.UI.Text wave_length;
    [SerializeField] UnityEngine.UI.Text angle;
    [SerializeField] UnityEngine.UI.Slider wave_angle_slider;
    public static SimulationControllerMenu Instance
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
    public void EmitButtonPressed()
    {
        float a = float.Parse(wave_length.text);
        float b = float.Parse(angle.text);
        SimulationController.Instance.Emit(a, b);
    }
    public void WaveAngleSliderValueChanged()
    {
        float a = float.Parse(wave_length.text);
        float b = wave_angle_slider.value;
        SimulationController.Instance.Emit(a, b);
    }
}
