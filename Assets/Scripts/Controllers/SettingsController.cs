using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsController : MonoBehaviour
{
    [SerializeField] DefaultSettingsScriptableObject default_settings;
    public DefaultSettingsScriptableObject DefaultSettings => default_settings;

    const string DefaultFolderName = "JsonFiles";
    const string DefaultFileName = "SettingsControllerSave";

    static SettingsController instance;
    public static SettingsController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void OnApplicationQuit()
    {
        SaveSettingsToFile();
    }
    private void Start()
    {
        LoadSettingsFromFile();
    }
    public void LoadSettingsFromFile()
    {
        Debug.Log("Load Settings From JSON");
        if (!File.Exists(SaveFilePath))
        {
            LoadDefaultSettings();
            Debug.Log("Failed to load. Applying default.");
            return;
        }

        string json = File.ReadAllText(SaveFilePath);
        SettingsControllerJSONFormat json_obj = JsonUtility.FromJson<SettingsControllerJSONFormat>(json);

        FreeCam = json_obj.free_cam;
        Crosshair = json_obj.crosshair;

        TimeScale = json_obj.time_scale;

        MonitoringEmittersCount = json_obj.monitoring_emitters_count;
        MonitoringMinEmitting = json_obj.monitoring_min_emitting;
        MonitoringMaxEmitting = json_obj.monitoring_max_emitting;
        MonitoringEmittingOnCrosshair = json_obj.monitoring_emitting_on_crosshair;

        FieldWidth = json_obj.field_width;
        FieldHeight = json_obj.field_height;

    }
    public void SaveSettingsToFile()
    {
        SettingsControllerJSONFormat json_format = new SettingsControllerJSONFormat(Instance);
        string json = JsonUtility.ToJson(json_format);

        if (!Directory.Exists(SaveFileDirectory))
            Directory.CreateDirectory(SaveFileDirectory);

        File.Create(SaveFilePath).Dispose();

        File.WriteAllText(SaveFilePath, json);

        Debug.Log("Save Settings To JSON");
    }

    string SaveFilePath => Path.Combine(SaveFileDirectory, DefaultFileName);
    string SaveFileDirectory => Path.Combine(Application.dataPath, DefaultFolderName);
    public void LoadDefaultSettings()
    {
        FreeCam = DefaultSettings.free_cam;
        Crosshair = DefaultSettings.crosshair;

        TimeScale = DefaultSettings.time_scale;

        MonitoringEmittersCount = DefaultSettings.monitoring_emitters_count;
        MonitoringMinEmitting = DefaultSettings.monitoring_min_emitting;
        MonitoringMaxEmitting = DefaultSettings.monitoring_max_emitting;
        MonitoringEmittingOnCrosshair = DefaultSettings.monitoring_emitting_on_crosshair;

        FieldWidth = DefaultSettings.field_width;
        FieldHeight = DefaultSettings.field_height;

    }

    #region Variables

    #region FreeCam
    [SerializeField, SerializeProperty("FreeCam")]
    bool free_cam;
    public bool FreeCam
    {
        get => free_cam;
        set
        {
            bool prev = free_cam;
            free_cam = value;
            Debug.Log("FreeCam: " + prev + " ==> " + free_cam);
        }
    }
    #endregion
    #region Crosshair
    [SerializeField, SerializeProperty("Crosshair")]
    bool crosshair;
    public bool Crosshair
    {
        get => crosshair;
        set
        {
            bool prev = crosshair;
            crosshair = value;
            Debug.Log("Crosshair: " + prev + " ==> " + crosshair);
        }
    }
    #endregion

    #region TimeScale
    [SerializeField, SerializeProperty("TimeScale")]
    float time_scale;
    public float TimeScale
    {
        get => time_scale;
        set
        {
            float prev = time_scale;
            time_scale = value;
            Debug.Log("TimeScale: " + prev + " ==> " + time_scale);
        }
    }
    #endregion

    #region MonitoringEmittersCount
    [SerializeField, SerializeProperty("MonitoringEmittersCount")]
    bool monitoring_emitters_count;
    public bool MonitoringEmittersCount
    {
        get => monitoring_emitters_count;
        set
        {
            bool prev = monitoring_emitters_count;
            monitoring_emitters_count = value;
            Debug.Log("MonitoringEmittersCount");
        }
    }
    #endregion
    #region MonitoringMinEmitting
    [SerializeField, SerializeProperty("MonitoringMinEmitting")]
    bool monitoring_min_emitting;
    public bool MonitoringMinEmitting
    {
        get => monitoring_min_emitting;
        set
        {
            bool prev = monitoring_min_emitting;
            monitoring_min_emitting = value;
            Debug.Log("MonitoringMinEmitting: " + prev + " ==> " + monitoring_min_emitting);
        }
    }
    #endregion
    #region MonitoringMaxEmitting
    [SerializeField, SerializeProperty("MonitoringMaxEmitting")]
    bool monitoring_max_emitting;
    public bool MonitoringMaxEmitting
    {
        get => monitoring_max_emitting;
        set
        {
            bool prev = MonitoringMaxEmitting;
            monitoring_max_emitting = value;
            Debug.Log("MonitoringMaxEmitting: " + prev + " ==> " + monitoring_max_emitting);
        }
    }
    #endregion
    #region MonitoringEmittingOnCrosshair
    [SerializeField, SerializeProperty("MonitoringEmittingOnCrosshair")]
    bool monitoring_emitting_on_crosshair;
    public bool MonitoringEmittingOnCrosshair
    {
        get => monitoring_emitting_on_crosshair;
        set
        {
            bool prev = monitoring_emitting_on_crosshair;
            monitoring_emitting_on_crosshair = value;
            Debug.Log("MonitoringEmittingOnCrosshair: " + prev + " ==> " + monitoring_emitting_on_crosshair);
        }
    }
    #endregion

    #region FieldWidth
    [SerializeField, SerializeProperty("FieldWidth")]
    int field_width;
    public int FieldWidth
    {
        get => field_width;
        set
        {
            int prev = field_width;
            field_width = value;
            Debug.Log("FieldWidth: " + prev + " ==> " + field_width);
        }
    }
    #endregion
    #region FieldHeight
    [SerializeField, SerializeProperty("FieldHeight")]
    int field_height;
    public int FieldHeight
    {
        get => field_height;
        set
        {
            int prev = field_height;
            field_height = value;
            Debug.Log("FieldHeight: " + prev + " ==> " + field_height);
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
        MonitoringEmittersCount = DefaultSettings.monitoring_emitters_count;
        MonitoringEmittingOnCrosshair = DefaultSettings.monitoring_emitting_on_crosshair;
        MonitoringMaxEmitting = DefaultSettings.monitoring_max_emitting;
        MonitoringMinEmitting = DefaultSettings.monitoring_min_emitting;
    }
    public void ResetFieldPage()
    {
        FieldWidth = DefaultSettings.field_width;
        FieldHeight = DefaultSettings.field_height;
    }
    #endregion
}
