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

        if (Input.GetKeyDown(PreferencesController.Instance.ActionsKeys["Close All Game UI Windows"]))
            CloseAllGameUIWindows();

        if (Input.GetKeyDown(PreferencesController.Instance.ActionsKeys["Shift Crosshair Visibility"]))
            ShiftCrosshairVisibility();

        if (Input.GetMouseButtonDown(1))
            RemoveUnpinnedGameUIWindows();

        
    }
    void RemoveUnpinnedGameUIWindows()
    {
        for (int i = 0; i < UIController.Instance.ActiveGameUIWindows.transform.childCount; i++)
            UIController.Instance.ActiveGameUIWindows.transform.GetChild(i).GetComponent<GameUIWindow>().DestroyIfUnpinned();
    }
    void CloseAllGameUIWindows()
    {
        for (int i = 0; i < UIController.Instance.ActiveGameUIWindows.transform.childCount; i++)
            UIController.Instance.ActiveGameUIWindows.transform.GetChild(i).GetComponent<GameUIWindow>().OnCloseButtonPressed();
    }
    void ShiftCrosshairVisibility()
    {
        SettingsController.Instance.OverallSetter("Crosshair", (!bool.Parse(SettingsController.Instance.OverallGetter("Crosshair").Item2)).ToString());
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
