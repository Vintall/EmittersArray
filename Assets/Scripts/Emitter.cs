using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour, IUIInteractable
{
    float wave_length;
    float phase_shift;
    float wave_period;

    public float WaveLength
    {
        get => wave_length;
        set
        {
            wave_length = value;
            SimulationController.Instance.OnChange();
        }
    }
    public float PhaseShift
    {
        get => phase_shift;
        set
        {
            phase_shift = value;
            SimulationController.Instance.OnChange();
        }
    }
    public float WavePeriod
    {
        get => wave_period;
        set
        {
            wave_period = value;
            SimulationController.Instance.OnChange();
        }
    }

    GameUIWindow game_ui_window = null;
    private void Update()
    {
        
    }
    public void CreateUIWindow()
    {
        if (game_ui_window != null)
            return;

        game_ui_window = GameUIWindowAssembler.CreateGameUIWindow();
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Wave Length", WaveLengthUIWindowGetter, WaveLengthUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Wave Period", WavePeriodUIWindowGetter, WavePeriodUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Phase Shift", PhaseShiftUIWindowGetter, PhaseShiftUIWindowSetter);
    }
    float WaveLengthUIWindowGetter() => WaveLength;
    void WaveLengthUIWindowSetter(float value) => WaveLength = value;
    float PhaseShiftUIWindowGetter() => PhaseShift;
    void PhaseShiftUIWindowSetter(float value) => PhaseShift = value;
    float WavePeriodUIWindowGetter() => WavePeriod;
    void WavePeriodUIWindowSetter(float value) => WavePeriod = value;

    private void Start()
    {
    }
}
