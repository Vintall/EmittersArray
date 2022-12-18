using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsController : MonoBehaviour
{
    [SerializeField] DefaultSettingsScriptableObject default_settings;
    public DefaultSettingsScriptableObject DefaultSettings => default_settings;
    static SettingsController instance;
    public static SettingsController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    const string DefaultFolderName = "JsonFiles";
    const string DefaultFileName = "SettingsControllerSave";
    string SaveFileDirectory => Path.Combine(Application.dataPath, DefaultFolderName);
    string SaveFilePath => Path.Combine(SaveFileDirectory, DefaultFileName);

    public delegate void OnSetSettingValueDelegat(string key);
    event OnSetSettingValueDelegat OnSetSettingValue; // setter handlers. in handler we supposed to check for current key (- - - if(key != "our key") return; - - -)
    public void RegisterSetterEventHandler(OnSetSettingValueDelegat handler) => OnSetSettingValue += handler;
    public void UnRegisterSetterEventHandler(OnSetSettingValueDelegat handler) => OnSetSettingValue -= handler;

    Dictionary<string, (DefaultSettingsScriptableObject.DataTypes, string)> settings = null; // settings storage
    public (DefaultSettingsScriptableObject.DataTypes, string) OverallGetter(string key)
    { // Getter for every node in dictionary. 
        if (!settings.ContainsKey(key))
            throw new System.Exception("Key: \"" + key + "\" not exist!");

        return settings[key];
    }
    public void OverallSetter(string key, string value)
    { // Setter for every node in dictionary. Notiry every interesting side about all changes.
        if (!settings.ContainsKey(key))
            throw new System.Exception("Key: \"" + key + "\" not exist!");

        settings[key] = (settings[key].Item1, value);
        OnSetSettingValue(key);
    }
    public void AddSettingNode(string key, DefaultSettingsScriptableObject.DataTypes type, string value)
    {
        if (settings == null)
            settings = new Dictionary<string, (DefaultSettingsScriptableObject.DataTypes, string)>();

        settings.Add(key, (type, value));
        OnSetSettingValue(key);
    }
    void Testsdf(string key)//--------------------------
    {
        Debug.Log("Setting :\"" + key +"\"");
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

        if (settings != null)
            settings.Clear();

        try
        {
            foreach (string node in json_obj.settings.Keys)
                AddSettingNode(node, json_obj.settings[node].Item1, json_obj.settings[node].Item2);
        }
        catch
        {
            LoadDefaultSettings();
        }
    }
    public void LoadDefaultSettings()
    {
        if (settings != null)
            settings.Clear();

        foreach (string node in DefaultSettings.SettingsDictionary.Keys)
            AddSettingNode(node, DefaultSettings.SettingsDictionary[node].Item1, DefaultSettings.SettingsDictionary[node].Item2);
    }
    public void SaveSettingsToFile()
    {
        SettingsControllerJSONFormat json_format = new SettingsControllerJSONFormat(settings);
        string json = JsonUtility.ToJson(json_format);

        if (!Directory.Exists(SaveFileDirectory))
            Directory.CreateDirectory(SaveFileDirectory);

        File.Create(SaveFilePath).Dispose();

        File.WriteAllText(SaveFilePath, json);

        Debug.Log("Save Settings To JSON");
    }
    private void OnApplicationQuit()
    {
        SaveSettingsToFile();
    }
    private void Start()
    {
        RegisterSetterEventHandler(Testsdf);
        LoadSettingsFromFile();
    }

    

    #region ResetToDefault

    public void ResetCameraMenu()
    {
        OverallSetter("Crosshair", DefaultSettings.SettingsDictionary["Crosshair"].Item2); 
    }
    public void ResetSimulationMenu()
    {
        settings["Time Scale"] = DefaultSettings.SettingsDictionary["Time Scale"];
    }
    public void ResetMonitoringPage()
    {
        OverallSetter("Monitoring Emitters Count", DefaultSettings.SettingsDictionary["Monitoring Emitters Count"].Item2);
        OverallSetter("Monitoring Emitting On Crosshair", DefaultSettings.SettingsDictionary["Monitoring Emitting On Crosshair"].Item2);
        OverallSetter("Monitoring Max Emitting", DefaultSettings.SettingsDictionary["Monitoring Max Emitting"].Item2);
        OverallSetter("Monitoring Min Emitting", DefaultSettings.SettingsDictionary["Monitoring Min Emitting"].Item2);
    }
    public void ResetFieldPage()
    {
        OverallSetter("Field Width", DefaultSettings.SettingsDictionary["Field Width"].Item2);
        OverallSetter("Field Height", DefaultSettings.SettingsDictionary["Field Height"].Item2);
    }
    #endregion
}
