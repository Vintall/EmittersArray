using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] Transform precise_plane;
    [SerializeField] Transform interference_plane;

    public Material interferense_plane_material;
    private void Awake()
    {
        instance = this;
    }
    public void PrecisePlaneStateChange(bool state)
    {
        precise_plane.gameObject.SetActive(state);
    }
}
