using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] Material active_material;
    [SerializeField] Material not_active_material;
    [SerializeField, Range(0.01f, 1)] float active_time;

    float wave_length;
    float shift;
    void Start()
    {
        
    }
    IEnumerator Activate()
    {
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = active_material;
        yield return new WaitForSeconds(active_time);
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = not_active_material;
    }
    void Update()
    {

    }
    public void EmitWave()
    {
        StartCoroutine("Activate");
    }
}
