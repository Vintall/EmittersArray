using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindowAssembler : MonoBehaviour
{
    public static GameUIWindow CreateGameUIWindow()
    {
        Transform game_ui_window = Instantiate(AssetHolder.Instance.GameUIWindow, UIController.Instance.ActiveGameUIWindows.transform).transform;
        return game_ui_window.gameObject.GetComponent<GameUIWindow>();
    }
    public static GameUIWindowIntField CreateGameUIWindowIntField(GameUIWindow target_window, 
        string variable_name, 
        GameUIWindowField.GetDelegate<int> get_delegate, 
        GameUIWindowField.SetDelegate<int> set_delegate)
    {
        Transform game_ui_window_field_transform = Instantiate(AssetHolder.Instance.GameUIWindowIntField, target_window.MainWindow.transform).transform;
        GameUIWindowIntField game_ui_window_field = game_ui_window_field_transform.gameObject.GetComponent<GameUIWindowIntField>();
        game_ui_window_field.InstantiateField(variable_name, get_delegate, set_delegate);

        return game_ui_window_field;
    }
    public static GameUIWindowFloatField CreateGameUIWindowFloatField(GameUIWindow target_window,
        string variable_name,
        GameUIWindowField.GetDelegate<float> get_delegate,
        GameUIWindowField.SetDelegate<float> set_delegate)
    {
        Transform game_ui_window_field_transform = Instantiate(AssetHolder.Instance.GameUIWindowFloatField, target_window.MainWindow.transform).transform;
        GameUIWindowFloatField game_ui_window_float_field = game_ui_window_field_transform.gameObject.GetComponent<GameUIWindowFloatField>();
        game_ui_window_float_field.InstantiateField(variable_name, get_delegate, set_delegate);

        return game_ui_window_float_field;
    }
}
