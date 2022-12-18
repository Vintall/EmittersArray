using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementInputSheet : InputSheet
{
    event InputDelegat OnMoveForward;
    event InputDelegat OnMoveBack;
    event InputDelegat OnMoveLeft;
    event InputDelegat OnMoveRight;

    event InputDelegat OnMoveUp;
    event InputDelegat OnMoveDown;

    event InputDelegat OnCheckBoost;

    event InputDelegat OnStartLooking;
    event InputDelegat OnStopLooking;
    event InputDelegat OnLooking;

    public override void OnWork()
    {
        OnCheckBoost();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Left"]))
            OnMoveLeft();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Right"]))
            OnMoveRight();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Forward"]))
            OnMoveForward();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Back"]))
            OnMoveBack();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Up"]))
            OnMoveUp();

        if (Input.GetKey(PreferencesController.Instance.ActionsKeys["Move Down"]))
            OnMoveDown();

        if (Input.GetMouseButtonDown(1))
            OnStartLooking();

        if (Input.GetMouseButtonUp(1))
            OnStopLooking();

        if (Input.GetMouseButton(1))
            OnLooking();
    }

    public override void OnActivate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        //throw new System.NotImplementedException();
    }

    public void Start()
    {
        OnMoveForward += GameController.Instance.PlayerFreeCam.OnMoveForward;
        OnMoveBack += GameController.Instance.PlayerFreeCam.OnMoveBack;
        OnMoveLeft += GameController.Instance.PlayerFreeCam.OnMoveLeft;
        OnMoveRight += GameController.Instance.PlayerFreeCam.OnMoveRight;

        OnMoveUp += GameController.Instance.PlayerFreeCam.OnMoveUp;
        OnMoveDown += GameController.Instance.PlayerFreeCam.OnMoveDown;

        OnCheckBoost += GameController.Instance.PlayerFreeCam.OnCheckBoost;

        OnStartLooking += GameController.Instance.PlayerFreeCam.OnStartLooking;
        OnStopLooking += GameController.Instance.PlayerFreeCam.OnStopLooking;
        OnLooking += GameController.Instance.PlayerFreeCam.OnLooking;
    }
}
