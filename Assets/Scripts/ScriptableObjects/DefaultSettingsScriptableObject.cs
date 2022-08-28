using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSettingsFile", menuName = "ScriptableObjects/DefaultSettings")]
public class DefaultSettingsScriptableObject : ScriptableObject
{
    //Camera
    public bool free_cam;
    public bool crosshair;
    
    //Simulation
    public double time_scale;

    //Monitoring
    public bool emitters_count;
    public bool max_emitting;
    public bool min_emitting;
    public bool emitting_on_crosshair;

    //Field
    public int field_width;
    public int field_height;

    //PhasedArrayGeneration
    public int antennas_count;
    public double wave_length;
    public double distance_between_emitters;
}
