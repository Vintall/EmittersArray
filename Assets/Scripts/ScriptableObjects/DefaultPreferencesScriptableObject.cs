using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPreferences", menuName = "ScriptableObjects")]
public class DefaultPreferencesScriptableObject : ScriptableObject
{
    [System.Serializable]
    public struct ActionKeys
    {
        public string name;
        public KeyCode key;
    }
    [System.Serializable]
    public struct InputSheet
    {
        public string sheet_name;
        public ActionKeys[] action_keys;
    }
    public InputSheet[] input_sheets;

    public List<ActionKeys> AllActionKeys
    {
        get
        {
            List<ActionKeys> result = new List<ActionKeys>();

            foreach(InputSheet sheet in input_sheets)
                foreach(ActionKeys key in sheet.action_keys)
                    result.Add(key);

            return result;
        }
    }
}
