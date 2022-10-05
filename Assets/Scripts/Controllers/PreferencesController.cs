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

    #region Variables

    #region MoveForward
    [SerializeField, SerializeProperty("MoveForward")]
    KeyCode move_forward;
    public KeyCode MoveForward
    {
        get => move_forward;
        set
        {
            KeyCode prev = move_forward;
            move_forward = value;
            Debug.Log("MoveForward-Preference: " + prev + " ==> " + move_forward);
        }
    }
    #endregion
    #region MoveLeft
    [SerializeField, SerializeProperty("MoveLeft")]
    KeyCode move_left;
    public KeyCode MoveLeft
    {
        get => move_left;
        set
        {
            KeyCode prev = move_left;
            move_left = value;
            Debug.Log("MoveLeft-Preference: " + prev + " ==> " + move_left);
        }
    }
    #endregion
    #region MoveRight
    [SerializeField, SerializeProperty("MoveRight")]
    KeyCode move_right;
    public KeyCode MoveRight
    {
        get => move_right;
        set
        {
            KeyCode prev = move_right;
            move_right = value;
            Debug.Log("MoveRight-Preference: " + prev + " ==> " + move_right);
        }
    }
    #endregion
    #region MoveBack
    [SerializeField, SerializeProperty("MoveBack")]
    KeyCode move_back;
    public KeyCode MoveBack
    {
        get => move_back;
        set
        {
            KeyCode prev = move_back;
            move_back = value;
            Debug.Log("MoveBack-Preference: " + prev + " ==> " + move_back);
        }
    }
    #endregion

    #endregion


    public void LoadDefaultPreferences()
    {
        MoveForward = DefaultPreferences.move_forward;
        MoveLeft = DefaultPreferences.move_left;
        MoveBack = DefaultPreferences.move_back;
        MoveRight = DefaultPreferences.move_right;
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

        MoveForward = json_obj.move_forward;
        MoveLeft = json_obj.move_left;
        MoveBack = json_obj.move_back;
        MoveRight = json_obj.move_right;
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

    public void ResetPreferencesMenu()
    {
        MoveForward = DefaultPreferences.move_forward;
        MoveLeft = DefaultPreferences.move_left;
        MoveBack = DefaultPreferences.move_back;
        MoveRight = DefaultPreferences.move_right;
    }
}
