using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour, IUIInteractable
{
    float wave_length;
    public float WaveLength
    {
        get => wave_length;
        set => wave_length = value;
    }
    private void Update()   // Just a test
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            CreateUIWindow();
        }
    }
    public void CreateUIWindow()
    {
        GameUIWindow game_ui_window = GameUIWindowAssembler.CreateGameUIWindow();

        GameUIWindowFloatField wave_length_field = GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Wave Length", WaveLengthUIWindowGetter, WaveLengthUIWindowSetter);
        
    }
    float WaveLengthUIWindowGetter() => WaveLength;
    void WaveLengthUIWindowSetter(float value) => WaveLength = value;

    private void Start()
    {
    }
}
