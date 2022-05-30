using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBar : MonoBehaviour
{
    static MainBar instance;
    
    public static MainBar Instance
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
    private void Start()
    {
        CloseAll();
    }
    void CloseAll()
    {
        SimulationControllerMenu.Instance.gameObject.SetActive(false);
        AntennaArrayControllerMenu.Instance.gameObject.SetActive(false);
        SettingsMenu.Instance.gameObject.SetActive(false);
    }
    public void GoToMainProgramButtonPressed()
    {
        CloseAll();
    }
    public void AntennaArrayControllerMenuButtonPressed()
    {
        CloseAll();
        AntennaArrayControllerMenu.Instance.gameObject.SetActive(true);
    }
    public void SimulationControllerMenuButtonPressed()
    {
        CloseAll();
        SimulationControllerMenu.Instance.gameObject.SetActive(true);
    }
    public void SettingsMenuButtonPressed()
    {
        CloseAll();
        SettingsMenu.Instance.gameObject.SetActive(true);
    }
}
