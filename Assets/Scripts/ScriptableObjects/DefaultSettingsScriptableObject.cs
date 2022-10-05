using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSettingsFile", menuName = "ScriptableObjects")]
public class DefaultSettingsScriptableObject : ScriptableObject
{
    //Camera
    public bool free_cam;
    public bool crosshair;
    
    //Simulation
    public float time_scale;

    //Monitoring
    public bool monitoring_emitters_count;
    public bool monitoring_max_emitting;
    public bool monitoring_min_emitting;
    public bool monitoring_emitting_on_crosshair;

    //Field
    public int field_width;
    public int field_height;

}
