using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesSheetName : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text text;

    public void InitializePreferencesSheetName(string name)
    {
        text.text = name;
        this.name = this.name + ": " + name;
    }
}
