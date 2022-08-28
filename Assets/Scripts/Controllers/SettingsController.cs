using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsController : MonoBehaviour
{
    [SerializeField] DefaultSettingsScriptableObject default_settings;
    public DefaultSettingsScriptableObject DefaultSettings => default_settings;

    const string DefaultFolderName = "SettingsPresets";
    const string DefaultFileName = "SettingsPreset1";
    
    static SettingsController instance;
    public static SettingsController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void LoadSettingsFromFile(string file_name)
    {
        Path.Combine(Application.dataPath, DefaultFolderName, DefaultFileName);
    }
    public void SaveSettingsToFile(string file_name)
    {
        
    }
    public void LoadDefaultSettings()
    {
        FreeCam = DefaultSettings.free_cam;
        Crosshair = DefaultSettings.crosshair;
        TimeScale = DefaultSettings.time_scale;
    }

    #region Variables

    #region FreeCam
    [SerializeField] bool free_cam;
    public bool FreeCam
    {
        get => free_cam;
        set
        {
            free_cam = value;
            Debug.Log("free_cam");
        }
    }
    #endregion
    #region Crosshair
    [SerializeField] bool crosshair;
    public bool Crosshair
    {
        get => crosshair;
        set
        {
            crosshair = value;
            Debug.Log("crosshair");
        }
    }
    #endregion

    #region TimeScale
    [SerializeField] double time_scale;
    public double TimeScale
    {
        get => time_scale;
        set
        {
            time_scale = value;
            Debug.Log("time_scale");
        }
    }
    #endregion

    #region MonitoringEmittersCount
    [SerializeField] bool monitoring_emitters_count;
    public bool MonitoringEmittersCount
    {
        get => monitoring_emitters_count;
        set
        {
            monitoring_emitters_count = value;
            Debug.Log("monitoring_emitters_count");
        }
    }
    #endregion
    #region MonitoringMinEmitting
    [SerializeField] bool monitoring_min_emitting;
    public bool MonitoringMinEmitting
    {
        get => monitoring_min_emitting;
        set
        {
            monitoring_min_emitting = value;
            Debug.Log("monitoring_min_emitting");
        }
    }
    #endregion
    #region MonitoringMaxEmitting
    [SerializeField] bool monitoring_max_emitting;
    public bool MonitoringMaxEmitting
    {
        get => monitoring_max_emitting;
        set
        {
            monitoring_max_emitting = value;
            Debug.Log("monitoring_max_emitting");
        }
    }
    #endregion
    #region MonitoringEmittingOnCrosshair
    [SerializeField] bool monitoring_emitting_on_crosshair;
    public bool MonitoringEmittingOnCrosshair
    {
        get => monitoring_emitting_on_crosshair;
        set
        {
            monitoring_emitting_on_crosshair = value;
            Debug.Log("monitoring_emitting_on_crosshair");
        }
    }
    #endregion

    #region FieldWidth
    [SerializeField] int field_width;
    public int FieldWidth
    {
        get => field_width;
        set
        {
            field_width = value;
            Debug.Log("field_width");
        }
    }
    #endregion
    #region FieldHeight
    [SerializeField] int field_height;
    public int FieldHeight
    {
        get => field_height;
        set
        {
            field_height = value;
            Debug.Log("field_height");
        }
    }
    #endregion

    #region AntennasCount
    [SerializeField] int antennas_count;
    public int AntennasCount
    {
        get => antennas_count;
        set
        {
            antennas_count = value;
            Debug.Log("antennas_count");
        }
    }
    #endregion
    #region WaveLength
    [SerializeField] double wave_length;
    public double WaveLength
    {
        get => wave_length;
        set
        {
            wave_length = value;
            Debug.Log("wave_length");
        }
    }
    #endregion
    #region DistanceBetweenEmitters
    [SerializeField] double distance_between_emitters;
    public double DistanceBetweenEmitters
    {
        get => distance_between_emitters;
        set
        {
            distance_between_emitters = value;
            Debug.Log("distance_between_emitters");
        }
    }
    #endregion

    #endregion

    #region ResetToDefault

    public void ResetCameraMenu()
    {
        FreeCam = default_settings.free_cam;
        Crosshair = default_settings.crosshair;
    }
    public void ResetSimulationMenu()
    {
        TimeScale = default_settings.time_scale;
    }
    public void ResetMonitoringPage()
    {
        MonitoringEmittersCount = DefaultSettings.emitters_count;
        MonitoringEmittingOnCrosshair = DefaultSettings.emitting_on_crosshair;
        MonitoringMaxEmitting = DefaultSettings.max_emitting;
        MonitoringMinEmitting = DefaultSettings.min_emitting;
    }
    public void ResetFieldPage()
    {
        FieldWidth = DefaultSettings.field_width;
        FieldHeight = DefaultSettings.field_height;
    }
    public void ResetPhasedArrayGenerationPage()
    {
        AntennasCount = DefaultSettings.antennas_count;
        WaveLength = DefaultSettings.wave_length;
        DistanceBetweenEmitters = DefaultSettings.distance_between_emitters;
    }
    #endregion
}
