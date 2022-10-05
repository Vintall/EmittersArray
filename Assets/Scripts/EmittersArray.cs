using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmittersArray : MonoBehaviour
{
    //public void GenerateAntennaArray()
    //{
    //    int emitters_count = SettingsController.Instance.EmittersCount;
    //    float distance_between_emitters = (float)SettingsController.Instance.DistanceBetweenEmitters;

    //    for (int i = transform.childCount - 1; i >= 0; i--)
    //    {
    //        Destroy(transform.GetChild(i).gameObject);
    //    }
    //    for (int i = 0; i < emitters_count; i++) //placement
    //    {
    //        Transform buff = EmmitersPool.Instance.TakeEmitter();
    //        buff.parent = transform;
    //        buff.localPosition = new Vector3(
    //            distance_between_emitters * (1 - emitters_count + 2 * i) / 2, //((1 - emitters_count) * distance_between_emitters / 2) + i * distance_between_emitters, 
    //            0,
    //            0);
    //    }
    //}
}
