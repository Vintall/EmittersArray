using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaArrayControllerMenu : MonoBehaviour
{
    static AntennaArrayControllerMenu instance;

    [SerializeField] UnityEngine.UI.Text antennas_count;
    [SerializeField] UnityEngine.UI.Text antennas_distance;
    public static AntennaArrayControllerMenu Instance
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
    public void GenerateAntennaArray()
    {
        try
        {
            int a = int.Parse(antennas_count.text);
            float b = float.Parse(antennas_distance.text);
            AntennaArrayController.Instance.GenerateAntennaArray(a, b);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
