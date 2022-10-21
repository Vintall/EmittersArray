using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    static SimulationController instance;
    public static SimulationController Instance => instance;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void Start()
    {
        SettingsController.Instance.RegisterSetterEventHandler(OnTimeScaleChanged);
    }

    [SerializeField] InterferencePlane plane;
    [SerializeField] Material plane_material = null;
    public Material PlaneMaterial
    {
        get
        {
            if (plane_material == null)
                plane_material = plane.GetComponent<MeshRenderer>().material;

            return plane_material;
        }
    }
    List<Transform> emitters = new List<Transform>();
    
    void OnTimeScaleChanged(string key)
    {
        if (key != "Time Scale")
            return;

        Time.timeScale = float.Parse(SettingsController.Instance.OverallGetter("Time Scale").Item2);
    }
    public void OnEmitterAdded(Transform emitter)
    {
        emitters.Add(emitter);
        OnChange();
    }
    public void OnEmitterRemoved(Transform emitter)
    {
        emitters.Remove(emitter);
    }
    public void OnChange()
    {
        PlaneMaterial.SetInt("_antenna_count", emitters.Count);
        PlaneMaterial.SetFloat("_sheet_size", 100f);

        Vector4[] points = new Vector4[100];
        float[] len = new float[100];
        float[] per = new float[100];
        float[] shift = new float[100];

        for (int i = 0; i < emitters.Count && i < 100; i++)
        {
            Emitter cur_emitter = emitters[i].GetComponent<Emitter>();
            points[i] = new Vector4(emitters[i].position.x, emitters[i].position.z, 0, 0);
            len[i] = cur_emitter.WaveLength;
            per[i] = cur_emitter.WavePeriod;
            shift[i] = cur_emitter.PhaseShift;
        }

        PlaneMaterial.SetVectorArray("_positions", points);

        PlaneMaterial.SetFloatArray("_wave_length", len);
        PlaneMaterial.SetFloatArray("_wave_period", per);
        PlaneMaterial.SetFloatArray("_phase_shift", shift);

        PlaneMaterial.SetColor("_max_amplitude_color", Color.red);
        PlaneMaterial.SetColor("_min_amplitude_color", Color.black);
    }

}
