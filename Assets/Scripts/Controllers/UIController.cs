using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu_ui_gameObject;
    [SerializeField] GameObject main_ui_gameObject;

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
    }
    public void OpenMenuUI()
    {
        menu_ui_gameObject.SetActive(true);
        main_ui_gameObject.SetActive(false);
    }



    
}