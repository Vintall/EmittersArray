using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSheet : MonoBehaviour
{
    public enum CallType
    {
        OnActivate,
        OnDeactivate,
        OnWork
    }
    public void CallMethod(CallType call_type)
    {
        switch(call_type)
        {
            case CallType.OnActivate:
                OnActivate();
                break;
            case CallType.OnDeactivate:
                OnDeactivate();
                break;
            case CallType.OnWork:
                OnWork();
              break;
        }    
    }
    public abstract void OnActivate();
    public abstract void OnWork();
    public abstract void OnDeactivate();
    public delegate void InputDelegat();
    public delegate void InputDelegatWithString(string key);
}
