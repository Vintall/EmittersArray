using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesSheet : MonoBehaviour
{
    List<PreferenceField> fields = null;
    public List<PreferenceField> Fields => fields;

    public void InitializePreferencesSheet(DefaultPreferencesScriptableObject.InputSheet sheet)
    {//Pre-Initialization from default preferences (Only place, where all of the preferences is defined by hands)
        fields = new List<PreferenceField>();

        PreferencesSheetName name_entry = Instantiate(AssetHolder.Instance.PreferencesSheetName, transform).GetComponent<PreferencesSheetName>();
        name_entry.InitializePreferencesSheetName(sheet.sheet_name);

        PreferenceField preference_field;
        foreach(DefaultPreferencesScriptableObject.ActionKeys key in sheet.action_keys)
        {
            preference_field = Instantiate(AssetHolder.Instance.PreferencesField, transform).GetComponent<PreferenceField>();
            preference_field.InitializeField(key);
            name = sheet.sheet_name;

            fields.Add(preference_field);
        }
    }
}
