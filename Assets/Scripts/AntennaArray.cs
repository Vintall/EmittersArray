using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaArray : MonoBehaviour
{
    [SerializeField] GameObject antenna_asset;
    int antennas_count = 1;
    float distance_between_antennas = 1;
    //[SerializeField, Range(-60, 60)] int emmiting_angle = 0;
    //[SerializeField, Range(1, 30)] float wave_length = 5;

    //#region InspectorStuff
    //int antennas_count_buff = 1;
    //float distance_between_antennas_buff = 0;
    //int emmiting_angle_buff = 0;
    //float wave_length_buff = 5;

    //bool auto_refresh = false;
    //public bool AutoRefresh
    //{
    //    get
    //    {
    //        return auto_refresh;
    //    }
    //    set
    //    {
    //        auto_refresh = value;
    //        InspectorRefreshButtonPressed();
    //    }
    //}
    //public void CheckForChange()
    //{
    //    bool need_to_refresh = false;

    //    if (antennas_count != antennas_count_buff)
    //        need_to_refresh = true;

    //    if (distance_between_antennas != distance_between_antennas_buff)
    //        need_to_refresh = true;

    //    if (emmiting_angle != emmiting_angle_buff)
    //        need_to_refresh = true;

    //    if (wave_length != wave_length_buff)
    //        need_to_refresh = true;

    //    if (need_to_refresh)
    //    {
    //        antennas_count_buff = antennas_count;
    //        distance_between_antennas_buff = distance_between_antennas;
    //        emmiting_angle_buff = emmiting_angle;
    //        wave_length_buff = wave_length;

    //        InspectorRefreshButtonPressed();
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    if (auto_refresh)
    //        CheckForChange();
    //}
    //public void InspectorRefreshButtonPressed()
    //{
    //    RefreshAntennaArray();
    //}
    //#endregion
    public void GenerateAntennaArray(int count, float distance)
    {
        antennas_count = count;
        distance_between_antennas = distance;
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
