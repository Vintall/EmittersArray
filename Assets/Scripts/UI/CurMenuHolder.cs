using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurMenuHolder : MonoBehaviour
{
    List<IMenuPage> menu_pages;
    void FillMenuPages()
    {
        menu_pages = new List<IMenuPage>()
        {
            reset_all_page,
            phased_array_generation_page,
            field_page,
            monitoring_page,
            simulation_page,
            camera_page,
            preferences_page
        };
    }
    public void CloseAll()
    {
        if (menu_pages == null)
            FillMenuPages();

        foreach (IMenuPage page in menu_pages)
            page.DeactivateGameObject();

    }

    #region ResetAllPage
    [SerializeField] ResetAllMenuPage reset_all_page;
    public ResetAllMenuPage ResetAllPage => reset_all_page;
    public void OpenResetAllPage()
    {
        CloseAll();
        reset_all_page.ActivateGameObject();
    }
    #endregion

    #region PhasedArrayGenerationPage
    [SerializeField] PhasedArrayGenerationMenuPage phased_array_generation_page;
    public PhasedArrayGenerationMenuPage PhasedArrayGenerationPage => phased_array_generation_page;
    public void OpenPhasedArrayGenerationPage()
    {
        CloseAll();
        phased_array_generation_page.ActivateGameObject();
    }
    #endregion

    #region FieldPage
    [SerializeField] FieldMenuPage field_page;
    public FieldMenuPage FieldPage => field_page;
    public void OpenFieldPage()
    {
        CloseAll();
        field_page.ActivateGameObject();
    }
    #endregion

    #region MonitoringPage
    [SerializeField] MonitoringMenuPage monitoring_page;
    public MonitoringMenuPage MonitoringPage => monitoring_page;
    public void OpenMonitoringPage()
    {
        CloseAll();
        monitoring_page.ActivateGameObject();
    }
    #endregion

    #region SimulationPage
    [SerializeField] SimulationMenuPage simulation_page;
    public SimulationMenuPage SimulationPage => simulation_page;
    public void OpenSimulationPage()
    {
        CloseAll();
        simulation_page.ActivateGameObject();
    }
    #endregion

    #region CameraPage
    [SerializeField] CameraMenuPage camera_page;
    public CameraMenuPage CameraPage => camera_page;
    public void OpenCameraPage()
    {
        CloseAll();
        camera_page.ActivateGameObject();
    }
    #endregion

    #region PreferencesPage
    [SerializeField] PreferencesMenuPage preferences_page;
    public PreferencesMenuPage PreferencesPage => preferences_page;
    public void OpenPreferencesPage()
    {
        CloseAll();
        preferences_page.ActivateGameObject();
    }
    #endregion
}
