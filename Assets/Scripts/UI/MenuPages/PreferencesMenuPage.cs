using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesMenuPage : MonoBehaviour, IMenuPage
{
    [System.Serializable]
    struct MyKey //Next time should do it through dictionary...  0_0
    {
        KeyCode key;
        [SerializeField] Text ui_representing;
        public KeyCode Key
        {
            get => key;
            set
            {
                key = value;
                ui_representing.text = key.ToString();
            }
        }
        public Text UiRepresenting => ui_representing;
        bool was_changed;
        public bool WasChanged
        {
            get => was_changed;
            set
            {
                was_changed = value;
                ui_representing.text = "";
            }
        }
    }
    [SerializeField] MyKey move_forward;
    [SerializeField] MyKey move_left;
    [SerializeField] MyKey move_right;
    [SerializeField] MyKey move_back;


    private void Start()
    {
        
    }
    private void Update()
    {
        InputChecker();
    }
    void InputChecker()
    {
        if (!input_checker_allowed)
            return;

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) //Check for all buttons
            if (Input.GetKeyDown(key))
            {
                if ((int)key >= 323 && (int)key <= 329) //Cut off mouse actions capture
                    continue;

                if (key == KeyCode.Escape)
                {
                    input_checker_allowed = false;
                    return;
                }

                input_checker_allowed = false;
                SendKey(key);
                return;
            }
    }
    string current_command = "";
    bool input_checker_allowed = false;

    void SendKey(KeyCode key)
    {
        switch (current_command)
        {
            case "Move forward":
                move_forward.Key = key;
                break;
            case "Move left":
                move_left.Key = key;
                break;
            case "Move back":
                move_back.Key = key;
                break;
            case "Move right":
                move_right.Key = key;
                break;
        }
        current_command = "";
    }

    #region UIInteractions
    public void ChangePreferenceClick(string command) 
    {
        if (input_checker_allowed)
            return;

        current_command = command;
        switch (command)
        {
            case "Move forward":
                move_forward.WasChanged = true;
                break;
            case "Move left":
                move_left.WasChanged = true;
                break;
            case "Move back":
                move_back.WasChanged = true;
                break;
            case "Move right":
                move_right.WasChanged = true;
                break;
        }
        
        input_checker_allowed = true;
    }
    public void ConfirmChangesButtonPressed()
    {
        if (move_forward.WasChanged)
            PreferencesController.Instance.MoveForward = move_forward.Key;

        if (move_left.WasChanged)
            PreferencesController.Instance.MoveLeft = move_left.Key;

        if (move_back.WasChanged)
            PreferencesController.Instance.MoveBack = move_back.Key;

        if (move_right.WasChanged)
            PreferencesController.Instance.MoveRight = move_right.Key;

        ClearAllSwitches();
        LoadFromController();
    }
    public void ResetToDefaultButtonPressed()
    {
        PreferencesController.Instance.ResetPreferencesMenu();
        LoadFromController();
    }
    #endregion

    void LoadFromController()
    {
        move_forward.Key = PreferencesController.Instance.MoveForward;
        move_left.Key = PreferencesController.Instance.MoveLeft;
        move_back.Key = PreferencesController.Instance.MoveBack;
        move_right.Key = PreferencesController.Instance.MoveRight;
    }
    void ClearAllSwitches()
    {
        move_forward.WasChanged = false; 
        move_left.WasChanged = false;
        move_back.WasChanged = false;
        move_right.WasChanged = false;
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
        ClearAllSwitches();
        LoadFromController();
    }
}
