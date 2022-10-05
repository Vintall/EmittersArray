using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIWindow : MonoBehaviour
{
    [SerializeField] Transform main_window;
    public Transform MainWindow => main_window;

    #region DragAndDrop
    Vector2 mouse_delta;
    bool is_current_drug;
    public void OnDrag()
    {
        if (!is_current_drug)
        {
            is_current_drug = true;
            mouse_delta = transform.position - Input.mousePosition;
        }
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + mouse_delta;
    }
    public void OnEndDrag()
    {
        is_current_drug = false;
    }
    #endregion

    #region WindowBarButtons
    bool is_window_minimized = false;
    public void OnMinimizeButtonPressed()
    {
        if (is_window_minimized)
            main_window.gameObject.SetActive(true);
        else main_window.gameObject.SetActive(false);

        is_window_minimized = !is_window_minimized;
    }
    public void OnPinButtonPressed()
    {
        Debug.Log("Pin");
    }
    public void OnCloseButtonPressed()
    {
        Destroy(gameObject);
    }
    #endregion

    public void InstantiateWindow()
    {

    }
}
