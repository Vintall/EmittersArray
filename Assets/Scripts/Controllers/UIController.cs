using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu_ui_gameObject;
    [SerializeField] GameObject main_ui_gameObject;
    [SerializeField] GameObject active_game_ui_windows;
    [SerializeField] GameObject crosshair;

    public GameObject MenuUIGameObject => menu_ui_gameObject;
    public GameObject MainUIGameObject => main_ui_gameObject;
    public GameObject ActiveGameUIWindows => active_game_ui_windows;
    public GameObject Crosshair => crosshair;

    static UIController instance;
    public static UIController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        SettingsController.Instance.RegisterSetterEventHandler(OnCrosshairToggled);
    }
    void OnCrosshairToggled(string key)
    {
        if (key != "Crosshair")
            return;

        crosshair.SetActive(bool.Parse(SettingsController.Instance.OverallGetter("Crosshair").Item2));
    }
    public void OpenMainUI()
    {
        main_ui_gameObject.SetActive(true);
        menu_ui_gameObject.SetActive(false);

        InputController.Instance.GoToActionPattern("Main UI");
    }
    public void OpenMenuUI()
    {
        menu_ui_gameObject.SetActive(true);
        main_ui_gameObject.SetActive(false);

        InputController.Instance.GoToActionPattern("Menu UI");
    }
}