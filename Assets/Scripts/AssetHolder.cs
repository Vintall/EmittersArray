using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetHolder : MonoBehaviour
{
    [SerializeField] GameObject emitter;
    [SerializeField] GameObject emitters_array;
    [SerializeField] Material emitter_active_material;
    [SerializeField] Material emitter_not_active_material;
    [SerializeField] GameObject game_ui_window;
    [SerializeField] GameObject game_ui_window_int_field;
    [SerializeField] GameObject game_ui_window_float_field;
    [SerializeField] GameObject game_ui_window_bool_field;
    [SerializeField] GameObject preferences_sheet;
    [SerializeField] GameObject preferences_sheet_name;
    [SerializeField] GameObject preferences_field;
    [SerializeField] GameObject preferences_reset_field;

    public GameObject EmittersArray => emitters_array;
    public GameObject PreferencesSheetName => preferences_sheet_name;
    public GameObject PreferencesResetField => preferences_reset_field;
    public GameObject PreferencesSheet => preferences_sheet;
    public GameObject PreferencesField => preferences_field;
    public GameObject GameUIWindowBoolField => game_ui_window_bool_field;
    public GameObject GameUIWindowFloatField => game_ui_window_float_field;
    public GameObject GameUIWindowIntField => game_ui_window_int_field;
    public GameObject GameUIWindow => game_ui_window;
    public GameObject EmitterPrefab => emitter;
    public Material EmitterActiveMaterial => emitter_active_material;
    public Material EmitterNotActiveMaterial => emitter_not_active_material;

    static AssetHolder instance;
    public static AssetHolder Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
