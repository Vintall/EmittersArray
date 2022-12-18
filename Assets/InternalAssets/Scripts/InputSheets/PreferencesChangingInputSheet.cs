using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesChangingInputSheet : InputSheet
{
    public override void OnWork()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CancelChanging();

        InputChecker();
    }
    void InputChecker()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) //Check for all buttons
            if (Input.GetKeyDown(key))
            {
                if ((int)key >= 323 && (int)key <= 329) //Cut off mouse actions capture
                    continue;

                if (key == KeyCode.Escape)
                    continue;

                SendKey(key);

                return;
            }
    }
    void SendKey(KeyCode key)
    {
        PreferencesMenuPage.Instance.ReceiveKey(key);
    }
    private void CancelChanging()
    {
        PreferencesMenuPage.Instance.CalcelChanging();
        InputController.Instance.GoToActionPattern("Menu UI");
    }

    public override void OnActivate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        //throw new System.NotImplementedException();
    }
}
