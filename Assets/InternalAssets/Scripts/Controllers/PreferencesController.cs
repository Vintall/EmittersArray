using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PreferencesController : MonoBehaviour
{
    [SerializeField] DefaultPreferencesScriptableObject default_preferences;
    public DefaultPreferencesScriptableObject DefaultPreferences => default_preferences;

    const string DefaultFolderName = "JsonFiles";
    const string DefaultFileName = "PreferencesController";
    string SaveFilePath => Path.Combine(SaveFileDirectory, DefaultFileName);
    string SaveFileDirectory => Path.Combine(Application.dataPath, DefaultFolderName);

    static PreferencesController instance;
    public static PreferencesController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        LoadPreferencesFromFile();
    }
    Dictionary<string, KeyCode> actions_keys = null;
    public Dictionary<string, KeyCode> ActionsKeys
    {
        get
        {
            if (actions_keys == null)
                LoadPreferencesFromFile();

                return actions_keys;
        }
    }

    public void LoadDefaultPreferences()
    {
        actions_keys = new Dictionary<string, KeyCode>();

        foreach(DefaultPreferencesScriptableObject.ActionKeys action in DefaultPreferences.AllActionKeys)
            actions_keys.Add(action.name, action.key);
    }
    private void OnApplicationQuit()
    {
        SavePreferencesToFile();
    }
    public void LoadPreferencesFromFile()
    {
        Debug.Log("Load Preferences From JSON");
        if (!File.Exists(SaveFilePath))
        {
            Debug.Log("Failed to load. Applying default.");
            LoadDefaultPreferences();
            return;
        }

        string json = File.ReadAllText(SaveFilePath);
        PreferencesControllerJSONFormat json_obj = JsonUtility.FromJson<PreferencesControllerJSONFormat>(json);

        if (json_obj.actions_key == null)
        {
            LoadDefaultPreferences();
            return;
        }


        actions_keys = new Dictionary<string, KeyCode>(json_obj.actions_key);
    }
    public void SavePreferencesToFile()
    {
        PreferencesControllerJSONFormat json_format = new PreferencesControllerJSONFormat(Instance);

        string json = JsonUtility.ToJson(json_format);

        if (!Directory.Exists(SaveFileDirectory))
            Directory.CreateDirectory(SaveFileDirectory);

        File.Create(SaveFilePath).Dispose();

        File.WriteAllText(SaveFilePath, json);

        Debug.Log("Save Preferences To JSON");
    }
}
