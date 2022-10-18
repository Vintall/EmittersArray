using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIInputSheet : InputSheet
{
    event InputDelegat GoToMenuUI;
    event InputDelegatWithString CreateObjectOnMap;
    public override void OnWork()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GoToMenuUI();

        if (Input.GetKeyDown(PreferencesController.Instance.ActionsKeys["Create Emitter"]))
            CreateObjectOnMap("Emitter");

        if (Input.GetKeyDown(PreferencesController.Instance.ActionsKeys["Create Emitters Array"]))
            CreateObjectOnMap("Emitters Array");
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
        GoToMenuUI += UIController.Instance.OpenMenuUI;
        CreateObjectOnMap += InterferencePlaneInteractionController.Instance.StartCreating;
    }
}
