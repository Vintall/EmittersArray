using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    static SimulationController instance;
    public static SimulationController Instance => instance;

    [SerializeField] EmittersArray antenna;
    [SerializeField] InterferencePlane plane;

    float wave_length;
    float rotation_angle;
    float wave_frequency;
    public float WaveFrequency
    {
        get => wave_frequency;
        set
        {
            wave_frequency = value;
            cur_material.SetFloat("_Wave_frequency", value);
        }
    }

    Material cur_material;
    public void Awake()
    {
        instance = this;
    }
    public void Emit(float wave_length, float rotation_angle)
    {
        this.wave_length = wave_length;
        this.rotation_angle = rotation_angle;

        float distance = 0;// (float)SettingsController.Instance.DistanceBetweenEmitters; --------------------

        float phase_shift = 360 * distance * Mathf.Sin(rotation_angle * Mathf.Deg2Rad) / wave_length;

        Transform antenna = null;// = AntennaArrayController.Instance.transform.GetChild(0);
        cur_material = plane.GetComponent<MeshRenderer>().material;
        
        List<Vector4> antenna_pos = new List<Vector4>();

        for (int i = 0; i < 100; i++)
            antenna_pos.Add(Vector4.zero);
        for (int i = 0; i < antenna.childCount; i++)
            antenna_pos[i] = new Vector4(antenna.GetChild(i).position.x, antenna.GetChild(i).position.z, 0, 0);

        cur_material.SetInt("_Antenna_count", antenna.childCount);
        cur_material.SetVectorArray("_Antenna_position", antenna_pos);

        cur_material.SetFloat("_Phase_shift", phase_shift);
        cur_material.SetFloat("_Wave_length", wave_length);

        cur_material.SetVector("_Sheet_position", new Vector4(plane.transform.position.x, plane.transform.position.z, 0, 0));
        cur_material.SetFloat("_Sheet_size", 100);
        #region Log
        Debug.Log("_Antenna_count: " + antenna.childCount);
        Debug.Log("_Phase_shift: " + phase_shift);
        Debug.Log("_Wave_length: " + wave_length);
        Debug.Log("_Sheet_position: " + new Vector4(plane.transform.position.x, plane.transform.position.z, 0, 0));
        Debug.Log("_Sheet_size: " + 100);
        #endregion
    }
}
