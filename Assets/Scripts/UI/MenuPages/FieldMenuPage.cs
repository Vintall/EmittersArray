using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMenuPage : MonoBehaviour, IMenuPage
{
    [SerializeField] UnityEngine.UI.InputField field_width;
    public int FieldWidth => int.Parse(field_width.text);
    bool field_width_was_changed = false;

    [SerializeField] UnityEngine.UI.InputField field_height;
    public int FieldHeight => int.Parse(field_height.text);
    bool field_height_was_changed = false;


    #region UIInteractions
    public void FieldWidthEndEditing() => field_width_was_changed = true;
    public void FieldHeightEndEditing() => field_height_was_changed = true;
    public void ResetToDefaultButtonPressed() => ResetToDefaul();
    public void ConfirmChangesButtonPressed() => ConfirmChanges();
    #endregion

    void ConfirmChanges()
    {
        if (field_width_was_changed)
            SettingsController.Instance.FieldWidth = FieldWidth;

        if (field_height_was_changed)
            SettingsController.Instance.FieldHeight = FieldHeight;
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
        field_width.text = SettingsController.Instance.FieldWidth.ToString();
        field_height.text = SettingsController.Instance.FieldHeight.ToString();

        field_width_was_changed = false;
        field_height_was_changed = false;
    }
}
