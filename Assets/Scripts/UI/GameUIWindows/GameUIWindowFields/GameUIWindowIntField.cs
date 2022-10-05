using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindowIntField : GameUIWindowField
{
    [SerializeField] UnityEngine.UI.InputField input_field;
    [SerializeField] UnityEngine.UI.Text text_field;

    GetDelegate<int> getter;
    SetDelegate<int> setter;
    public void InstantiateField(string variable_name, GetDelegate<int> _getter, SetDelegate<int> _setter)
    {
        text_field.text = variable_name;
        
        getter = _getter;
        setter = _setter;
        
        input_field.contentType = UnityEngine.UI.InputField.ContentType.IntegerNumber;

        if (getter != null)
            input_field.text = getter.Invoke().ToString();
        else
            Debug.LogError("Delegate is null");

        field_type = FieldType.Int;
    }
    public override void RefreshData()
    {
        
    }
    public void OnInputFieldValueEndEdit()
    {
        if (setter != null)
            setter.Invoke(int.Parse(input_field.text));
        else
            Debug.LogError("Delegate is null");
    }
}
