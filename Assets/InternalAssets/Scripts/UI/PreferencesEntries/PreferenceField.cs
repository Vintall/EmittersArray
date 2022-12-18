using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceField : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text title; // title.text - represented action name
    [SerializeField] UnityEngine.UI.Text key; // key.text - KeyCode in string format 
    public string ActionName => title.text;

    bool is_changing_allowed = true;
    public void LockChanging() => is_changing_allowed = false;
    public void UnLockChanging() => is_changing_allowed = true;

    public void InitializeField(DefaultPreferencesScriptableObject.ActionKeys key)
    {//Pre-Initialization from default preferences (Only place, where all of the preferences is defined by hands)
        title.text = key.name;
        gameObject.name = key.name;

        this.key.text = key.key.ToString();
    }
    public void InitializeField()
    {//Post-Initialization. Field already generated and contains represented action name. This method receives current key from PreferencesController
        KeyCode new_key = KeyCode.None;
        if (!PreferencesController.Instance.ActionsKeys.TryGetValue(title.text, out new_key))
            Debug.LogError("Action name not exist!");

        key.text = new_key.ToString();
    }
    public void OnChangePreferenceEntryPressed()
    {
        if (!is_changing_allowed)
            return;

        key.text = "";

        PreferencesMenuPage.Instance.OnStartChanging(title.text);
    }
    public void OnPreferenceResetButtonPressed()
    {
        foreach(DefaultPreferencesScriptableObject.ActionKeys default_key in PreferencesController.Instance.DefaultPreferences.AllActionKeys)
            if(default_key.name == title.text)
            {
                PreferencesController.Instance.ActionsKeys[title.text] = default_key.key;
                break;
            }

        InitializeField();
    }
}
