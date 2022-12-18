using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBar : MonoBehaviour
{
    [SerializeField] CurMenuHolder cur_menu_holder_instance;
    
    #region ButtonEvents
    public void CloseMenuPressed()
    {
        cur_menu_holder_instance.CloseAll();
        UIController.Instance.OpenMainUI();
    }
    public void InfoPressed()
    {
        cur_menu_holder_instance.OpenInfoPage();
    }
    public void FieldPressed()
    {
        cur_menu_holder_instance.OpenFieldPage();
    }
    public void SimulationPressed()
    {
        cur_menu_holder_instance.OpenSimulationPage();
    }
    public void CameraPressed()
    {
        cur_menu_holder_instance.OpenCameraPage();
    }
    public void PreferencesPressed()
    {
        cur_menu_holder_instance.OpenPreferencesPage();
    }
#endregion
}
