using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaArray : MonoBehaviour
{
    [SerializeField] GameObject antenna_asset;
    
    public void GenerateAntennaArray()
    {
        int antennas_count = SettingsController.Instance.AntennasCount;
        float distance_between_antennas = (float)SettingsController.Instance.DistanceBetweenEmitters;

        Debug.Log(antennas_count);
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < antennas_count; i++)
        {
            Transform buff = Instantiate(antenna_asset).transform;
            buff.parent = transform;
            buff.localPosition = new Vector3(
                -((antennas_count - 1) * distance_between_antennas / 2) + 
                i * distance_between_antennas, 0, 0);
        }
    }
}
