using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject marker. Contains all emitters on scene as childs.
/// </summary>
public class FreeEmittersHolder : MonoBehaviour
{
    static FreeEmittersHolder instance;
    public static FreeEmittersHolder Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
