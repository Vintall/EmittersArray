using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu_ui_gameObject;
    [SerializeField] GameObject main_ui_gameObject;
    [SerializeField] GameObject active_game_ui_windows;

    public GameObject MenuUIGameObject => menu_ui_gameObject;
    public GameObject MainUIGameObject => main_ui_gameObject;
    public GameObject ActiveGameUIWindows => active_game_ui_windows;

    static UIController instance;
    public static UIController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
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