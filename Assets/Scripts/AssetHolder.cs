using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetHolder : MonoBehaviour
{
    [SerializeField] GameObject emitter;
    [SerializeField] Material emitter_active_material;
    [SerializeField] Material emitter_not_active_material;
    [SerializeField] GameObject game_ui_window;
    [SerializeField] GameObject game_ui_window_int_field;
    [SerializeField] GameObject game_ui_window_float_field;

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
        instance = this;
    }
}
