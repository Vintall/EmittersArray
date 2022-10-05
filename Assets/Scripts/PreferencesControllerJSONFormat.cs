using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only valueble for saving parts of preferences class. Excluding fields, that can not be load from JSON (Singlton)
/// </summary>
public class PreferencesControllerJSONFormat
{
    public KeyCode move_forward;
    public KeyCode move_right;
    public KeyCode move_left;
    public KeyCode move_back;


    public PreferencesControllerJSONFormat(PreferencesController obj)
    {
        move_forward = obj.MoveForward;
        move_left = obj.MoveLeft;
        move_right = obj.MoveRight;
        move_back = obj.MoveBack;
    }
}
