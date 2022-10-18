using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindowBoolField : GameUIWindowField
{
    [SerializeField] UnityEngine.UI.Toggle toggle_field;
    [SerializeField] UnityEngine.UI.Text text_field;

    GetDelegate<bool> getter;
    SetDelegate<bool> setter;
    public void InstantiateField(string variable_name, GetDelegate<bool> _getter, SetDelegate<bool> _setter)
    {
        text_field.text = variable_name;

        getter = _getter;
        setter = _setter;

        if (getter != null)
            toggle_field.isOn = getter.Invoke();
        else
            Debug.LogError("Delegate is null");

        field_type = FieldType.Bool;
    }
    public override void RefreshData()
    {

    }
    public void OnToggleFieldValueChanged()
    {
        if (setter != null)
            setter.Invoke(toggle_field.isOn);
        else
            Debug.LogError("Delegate is null");
    }
}
