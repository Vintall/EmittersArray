using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    static InputController instance;
    public static InputController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [System.Serializable]
    public struct ActionInputSheet
    {
        [SerializeField] string name;
        public string Name => name;

        [SerializeField] InputSheet input_sheet;
        public InputSheet InputSheet => input_sheet;
    }
    
    [SerializeField] List<ActionInputSheet> input_sheets; // Input Sheet name and object bond
    InputSheet GetInputSheet(string name)
    {
        foreach (ActionInputSheet sheet in input_sheets)
            if (sheet.Name == name)
                return sheet.InputSheet;

        return null;
    }
    delegate void ActionsList(InputSheet.CallType call_type);

    Dictionary<string, ActionsList> action_patterns = new Dictionary<string, ActionsList>();
    (string, ActionsList) current_action_pattern = ("", null);
    

    private void RegisterActionPattern(string name, params string[] actions)
    {
        action_patterns.Add(name, null);

        foreach (string action in actions)
            action_patterns[name] += GetInputSheet(action).CallMethod;
    }
    public void GoToActionPattern(string action_name)
    {
        ActionsList result;
        if (!action_patterns.TryGetValue(action_name, out result))
        {
            Debug.LogError("Action Pattern change was failed. Action: \"" + action_name + "\" not exist!");
            return;
        }

        if (current_action_pattern.Item2 != null)
            current_action_pattern.Item2.Invoke(InputSheet.CallType.OnDeactivate);

        Debug.Log("Action Pattern was successfully changed to: \"" + action_name + "\"");
        current_action_pattern.Item1 = action_name;
        current_action_pattern.Item2 = result;

        current_action_pattern.Item2.Invoke(InputSheet.CallType.OnActivate);
    }
    private void Start()
    {
        RegisterActionPattern("Main UI", "Main UI", "Cam Movement", "Choosing Objects");
        RegisterActionPattern("Menu UI", "Menu UI", "Cam Movement");
        RegisterActionPattern("Preferences Changing", "Preferences Changing");
        RegisterActionPattern("Creating Objects", "Creating Objects", "Cam Movement");
        

        GoToActionPattern("Menu UI");
    }
    void CurrentActionPatternExecute()
    {
        if (current_action_pattern.Item2 == null) 
            return;

        current_action_pattern.Item2.Invoke(InputSheet.CallType.OnWork);
    }
    void Update()
    {
        CurrentActionPatternExecute();
    }
}
