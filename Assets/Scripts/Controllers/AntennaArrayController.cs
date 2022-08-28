using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaArrayController : MonoBehaviour
{
    [SerializeField] AntennaArray antenna_array;

    static AntennaArrayController instance;
    public static AntennaArrayController Instance => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void GenerateAntennaArray()
    {
        antenna_array.GenerateAntennaArray();
        
    }
}
