using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindowField : MonoBehaviour
{
    public enum FieldType // If I'll ever need to cast this class to child
    {
        Int,
        Float
    }
    protected FieldType field_type;
    public FieldType GetFieldType => field_type;

    public delegate T GetDelegate<T>();

    public delegate void SetDelegate<T>(T output);
    public virtual void RefreshData() { }
}
