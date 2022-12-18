using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesMenuPage : MonoBehaviour, IMenuPage
{
    static PreferencesMenuPage instance;
    public static PreferencesMenuPage Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    List<PreferencesSheet> sheets = null;
    public List<PreferencesSheet> Sheets
    { 
        get
        {
            if (sheets == null)
                InitializePreferencesMenuPage();

            return sheets;
        }
    }

    List<PreferenceField> all_fields = null;
    public List<PreferenceField> AllFields
    {
        get
        { //Fields list can not be changed after initialization. So, I can collect all of the fields onse, copy it, and then use copy.
            if (all_fields != null)
                return all_fields;

            List<PreferenceField> result = new List<PreferenceField>();

            foreach(PreferencesSheet sheet in Sheets)
                result.AddRange(sheet.Fields);

            return result;
        }
    }
    string current_action_on_change = "";
    public void OnStartChanging(string action_name)
    {
        LockPreferencesStartChanging();
        current_action_on_change = action_name;
        InputController.Instance.GoToActionPattern("Preferences Changing");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ReceiveKey(KeyCode key)
    {
        foreach(PreferenceField field in AllFields)
            if(field.ActionName == current_action_on_change)
            {
                PreferencesController.Instance.ActionsKeys[current_action_on_change] = key;

                field.InitializeField();
                break;
            }

        current_action_on_change = "";
        UnLockPreferencesStartChanging();
    }
    public void CalcelChanging()
    {
        foreach (PreferenceField field in AllFields)
            if (field.ActionName == current_action_on_change)
            {
                field.InitializeField();
                break;
            }
        current_action_on_change = "";
        UnLockPreferencesStartChanging();
    }
    public void LockPreferencesStartChanging()
    {// Locks changing entry on every field. This happens, when one field currently choosed for changing
        foreach (PreferenceField field in AllFields)
            field.LockChanging();

        
    }
    public void UnLockPreferencesStartChanging()
    {// UnLocks changing entry on every field. Now we can choose preference, we wanna change, by pressing on changing entry.
        foreach (PreferenceField field in AllFields)
            field.UnLockChanging();

        InputController.Instance.GoToActionPattern("Menu UI");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Start()
    {
        InitializePreferencesMenuPage();
    }
    private void Update()
    {
        
    }
    [SerializeField] Transform content;

    public void InitializePreferencesMenuPage()
    {//Pre-Initialization from default preferences (Only place, where all of the preferences is defined by hands)
        sheets = new List<PreferencesSheet>();

        PreferencesSheet sheet_obj;
        foreach (DefaultPreferencesScriptableObject.InputSheet sheet in PreferencesController.Instance.DefaultPreferences.input_sheets)
        {
            sheet_obj = Instantiate(AssetHolder.Instance.PreferencesSheet, content).GetComponent<PreferencesSheet>();
            sheet_obj.InitializePreferencesSheet(sheet);

            sheets.Add(sheet_obj);
        }
        Instantiate(AssetHolder.Instance.PreferencesResetField, content);
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
        
    }
}
