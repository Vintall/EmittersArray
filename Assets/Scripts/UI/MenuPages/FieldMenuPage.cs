using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMenuPage : MonoBehaviour, IMenuPage
{
    [SerializeField] UnityEngine.UI.InputField field_width;
    public int FieldWidth => int.Parse(field_width.text);

    [SerializeField] UnityEngine.UI.InputField field_height;
    public int FieldHeight => int.Parse(field_height.text);


    #region UIInteractions
    public void ResetToDefaultButtonPressed() => ResetToDefaul();
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    #endregion

    void ConfirmChanges()
    {
        SettingsController.Instance.OverallSetter("Field Width", FieldWidth.ToString());
        SettingsController.Instance.OverallSetter("Field Height", FieldHeight.ToString());
    }
    void ResetToDefaul()
    {
        SettingsController.Instance.ResetFieldPage();
        LoadOnActivation();
    }


    public void ActivateGameObject()
    {
        gameObject.SetActive(true);
        LoadOnActivation();
    }

    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    public void LoadOnActivation()
    {
        field_width.text = SettingsController.Instance.OverallGetter("Field Width").ToString();
        field_height.text = SettingsController.Instance.OverallGetter("Field Height").ToString();
    }
}
