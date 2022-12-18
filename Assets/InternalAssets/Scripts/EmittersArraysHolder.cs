using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject marker. Contains all emittersArrays on scene as childs.
/// </summary>
public class EmittersArraysHolder : MonoBehaviour
{
    static EmittersArraysHolder instance;
    public static EmittersArraysHolder Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
