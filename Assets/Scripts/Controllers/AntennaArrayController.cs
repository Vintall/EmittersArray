using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaArrayController : MonoBehaviour
{
    static AntennaArrayController instance;
    int antennas_count;
    float antennas_distance;

    public int AntennasCount
    {
        get
        {
            return antennas_count;
        }
    }
    public float AntennasDistance
    {
        get
        {
            return antennas_distance;
        }
    }
    public static AntennaArrayController Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public void GenerateAntennaArray(int count, float distance)
    {
        antennas_count = count;
        antennas_distance = distance;
        transform.GetChild(0).GetComponent<AntennaArray>().GenerateAntennaArray(count, distance);
    }
}
