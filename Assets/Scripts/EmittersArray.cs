using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmittersArray : MonoBehaviour, IUIInteractable
{
    List<Emitter> emitters = new List<Emitter>();
    MeshCollider array_collider = null;
    [SerializeField] Transform cylinder;
    public void GenerateEmittersArray()
    {
        foreach (Emitter emitter in emitters) // Removing existing emitters
        {
            emitter.ActivateCollider();
            EmittersPool.PlaceEmitter(emitter.transform);
        }
        cylinder.localScale = new Vector3(1, 1, 1);

        for (int i = 0; i < emitters_count; i++) // Placing new emitters
        {
            Emitter buff = EmittersPool.TakeEmitter().GetComponent<Emitter>();

            emitters.Add(buff);

            buff.DeactivateCollider();

            buff.WaveLength = WaveLength;
            buff.WavePeriod = WavePeriod;
            buff.PhaseShift = i * (360f * distance_between_emitters * Mathf.Sin(Angle * Mathf.Deg2Rad) / WaveLength) * Mathf.PI / 180f;

            buff.transform.parent = transform;

            buff.transform.localPosition = new Vector3(
                distance_between_emitters * (1 + 2 * i - emitters_count) / 2,
                0,
                0);
        }
        cylinder.localScale = new Vector3(0.7f, Mathf.Max(emitters_count * distance_between_emitters / 2, 1), 0.7f);
    }
    public void RemoveEmittersArray()
    {
        foreach (Emitter emitter in emitters) // Removing existing emitters
        {
            emitter.ActivateCollider();
            EmittersPool.PlaceEmitter(emitter.transform);
        }
        cylinder.localScale = new Vector3(1, 1, 1);

        if (game_ui_window != null)
            game_ui_window.OnCloseButtonPressed();

        emitters.Clear();
    }
    float wave_length;
    float angle;
    float wave_period;
    int emitters_count;
    float distance_between_emitters;

    private void Start()
    {
        if (array_collider == null)
            array_collider = cylinder.GetComponent<MeshCollider>();
    }
    public float DistanceBetweenEmitters
    {
        get => distance_between_emitters;
        set
        {
            distance_between_emitters = value;
            SimulationController.Instance.OnChange();
            GenerateEmittersArray();
        }
    }
    public int EmittersCount
    {
        get => emitters_count;
        set
        {
            emitters_count = value;
            SimulationController.Instance.OnChange();
            GenerateEmittersArray();
        }
    }
    public float WaveLength
    {
        get => wave_length;
        set
        {
            wave_length = value;
            SimulationController.Instance.OnChange();
            GenerateEmittersArray();
        }
    }
    public float Angle
    {
        get => angle;
        set
        {
            angle = value;
            SimulationController.Instance.OnChange();
            GenerateEmittersArray();
        }
    }
    public float WavePeriod
    {
        get => wave_period;
        set
        {
            wave_period = value;
            SimulationController.Instance.OnChange();
            GenerateEmittersArray();
        }
    }
    GameUIWindow game_ui_window = null;
    public void CreateUIWindow()
    {
        if (game_ui_window != null)
            return;

        game_ui_window = GameUIWindowAssembler.CreateGameUIWindow();
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Wave Length", WaveLengthUIWindowGetter, WaveLengthUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Wave Period", WavePeriodUIWindowGetter, WavePeriodUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Angle", AngleUIWindowGetter, AngleUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowIntField(game_ui_window, "Emitters Count", EmittersCountUIWindowGetter, EmittersCountUIWindowSetter);
        GameUIWindowAssembler.CreateGameUIWindowFloatField(game_ui_window, "Distance Between Emitters", DistanceBetweenEmittersUIWindowGetter, DistanceBetweenEmittersUIWindowSetter);
    }
    float WaveLengthUIWindowGetter() => WaveLength;
    void WaveLengthUIWindowSetter(float value) => WaveLength = value;
    float AngleUIWindowGetter() => Angle;
    void AngleUIWindowSetter(float value) => Angle = value;
    float WavePeriodUIWindowGetter() => WavePeriod;
    void WavePeriodUIWindowSetter(float value) => WavePeriod = value;
    int EmittersCountUIWindowGetter() => EmittersCount;
    void EmittersCountUIWindowSetter(int value) => EmittersCount = value;
    float DistanceBetweenEmittersUIWindowGetter() => DistanceBetweenEmitters;
    void DistanceBetweenEmittersUIWindowSetter(float value) => DistanceBetweenEmitters = value;
}
