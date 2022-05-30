using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController instance;
    [SerializeField] Transform precise_plane;
    [SerializeField] Transform interference_plane;
    public static GameController Instance
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
    public void PrecisePlaneStateChange(bool state)
    {
        precise_plane.gameObject.SetActive(state);
    }
}
