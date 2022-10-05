using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPreferences", menuName = "ScriptableObjects")]
public class DefaultPreferencesScriptableObject : ScriptableObject
{
    public KeyCode move_forward;
    public KeyCode move_left;
    public KeyCode move_back;
    public KeyCode move_right;
}
