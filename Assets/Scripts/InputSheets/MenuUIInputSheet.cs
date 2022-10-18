using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIInputSheet : InputSheet
{
    event InputDelegat GoToMainUI;
    public override void OnWork()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GoToMainUI();
    }

    public override void OnActivate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        //throw new System.NotImplementedException();
    }

    private void Start()
    {
        GoToMainUI += UIController.Instance.OpenMainUI;
    }
}
