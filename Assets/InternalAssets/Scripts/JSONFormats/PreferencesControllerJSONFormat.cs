using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only valueble for saving parts of preferences class. Excluding fields, that can not be load from JSON (Singlton)
/// </summary>
public class PreferencesControllerJSONFormat
{
    public Dictionary<string, KeyCode> actions_key;

    public PreferencesControllerJSONFormat(PreferencesController obj)
    {
        actions_key = new Dictionary<string, KeyCode>(obj.ActionsKeys);
    }
}
