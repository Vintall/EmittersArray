using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencePlane : MonoBehaviour
{
    private void Start()
    {
        GameController.Instance.interferense_plane_material = GetComponent<MeshRenderer>().material;
    }
}
