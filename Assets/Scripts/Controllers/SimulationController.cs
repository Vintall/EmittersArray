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
        SettingsController.Instance.RegisterSetterEventHandler(OnInterferencePlaneWidthChanged);
        SettingsController.Instance.RegisterSetterEventHandler(OnInterferencePlaneHeightChanged);
    }
    void OnInterferencePlaneWidthChanged(string key)
    {
        if (key != "Field Width")
            return;

        float width = float.Parse(SettingsController.Instance.OverallGetter("Field Width").Item2);
        float height = float.Parse(SettingsController.Instance.OverallGetter("Field Height").Item2);

        InterferencePlane.Instance.transform.localScale = new Vector3(width / 10, height / 10); // x/10, cause of basic size of plane. scale(1,1,1) => size(10, .., 10) 

        OnChange();
    }
    void OnInterferencePlaneHeightChanged(string key)
    {
        if (key != "Field Height")
            return;

        float width = float.Parse(SettingsController.Instance.OverallGetter("Field Width").Item2);
        float height = float.Parse(SettingsController.Instance.OverallGetter("Field Height").Item2);

        InterferencePlane.Instance.transform.localScale = new Vector3(width / 10, 1, height / 10); // x/10, cause of basic size of plane. scale(1,1,1) => size(10, .., 10) 

        OnChange();
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

        OnChange();
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
    {// Full shader data reset
        PlaneMaterial.SetInt("_antenna_count", emitters.Count);
        PlaneMaterial.SetVector("_sheet_size", new Vector4(float.Parse(SettingsController.Instance.OverallGetter("Field Width").Item2),
            float.Parse(SettingsController.Instance.OverallGetter("Field Height").Item2), 0, 0));

        const int emitters_max_size = 1000;

        //We need to pass max sized massive to shader.
        Vector4[] points = new Vector4[emitters_max_size];
        float[] len = new float[emitters_max_size];
        float[] per = new float[emitters_max_size];
        float[] shift = new float[emitters_max_size];

        for (int i = 0; i < emitters.Count && i < emitters_max_size; i++)
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
