using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencePlane : MonoBehaviour
{
    static InterferencePlane instance;
    public static InterferencePlane Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
