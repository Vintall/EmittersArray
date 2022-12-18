using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only valueble for saving parts of settings class. Excluding fields, that can not be load from JSON (Singlton)
/// </summary>
public class SettingsControllerJSONFormat
{
    public Dictionary<string, (DefaultSettingsScriptableObject.DataTypes, string)> settings;

    public SettingsControllerJSONFormat(Dictionary<string, (DefaultSettingsScriptableObject.DataTypes, string)> current_settings)
    {
        settings = new Dictionary<string, (DefaultSettingsScriptableObject.DataTypes, string)>(current_settings);
    }

}
