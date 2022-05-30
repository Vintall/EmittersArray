using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(AntennaArray))]
public class AntennaArray_Inspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //AntennaArray arr = (AntennaArray)target;
        
        //bool auto_refresh_choise_buff = GUILayout.Toggle(arr.AutoRefresh, "Refresh on change");

        //if (arr.AutoRefresh != auto_refresh_choise_buff)
        //{
        //    arr.AutoRefresh = auto_refresh_choise_buff;
        //}
        //if (!arr.AutoRefresh && GUILayout.Button("Refresh"))
        //{
        //    arr.InspectorRefreshButtonPressed();
        //}

    }
}
