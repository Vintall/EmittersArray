using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindowFloatField : GameUIWindowField
{
    [SerializeField] UnityEngine.UI.InputField input_field;
    [SerializeField] UnityEngine.UI.Text text_field;

    GetDelegate<float> getter;
    SetDelegate<float> setter;
    public void InstantiateField(string variable_name, GetDelegate<float> _getter, SetDelegate<float> _setter)
    {
        text_field.text = variable_name;

        getter = _getter;
        setter = _setter;

        //input_field.contentType = UnityEngine.UI.InputField.ContentType.DecimalNumbers;

        if (getter != null)
            input_field.text = getter.Invoke().ToString();
        else
            Debug.LogError("Delegate is null");

        field_type = FieldType.Float;
    }
    public override void RefreshData()
    {

    }
    public void OnInputFieldValueEndEdit()
    {
        if (setter != null)
            setter.Invoke(float.Parse(input_field.text));
        else
            Debug.LogError("Delegate is null");
    }
}
