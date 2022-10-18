using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only valueble for saving parts of settings class. Excluding fields, that can not be load from JSON (Singlton)
/// </summary>
public class SettingsControllerJSONFormat
{
    public bool free_cam;
    public bool crosshair;

    public float time_scale;

    public bool monitoring_emitters_count;
    public bool monitoring_min_emitting;
    public bool monitoring_max_emitting;
    public bool monitoring_emitting_on_crosshair;

    public int field_width;
    public int field_height;


    public SettingsControllerJSONFormat(SettingsController obj)
    {
        free_cam = obj.FreeCam;
        crosshair = obj.Crosshair;
        time_scale = obj.TimeScale;
        monitoring_emitters_count = obj.MonitoringEmittersCount;
        monitoring_min_emitting = obj.MonitoringMinEmitting;
        monitoring_max_emitting = obj.MonitoringMaxEmitting;
        monitoring_emitting_on_crosshair = obj.MonitoringEmittingOnCrosshair;
        field_width = obj.FieldWidth;
        field_height = obj.FieldHeight;
    }

}
