using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingObjectsInputSheet : InputSheet
{
    static ChoosingObjectsInputSheet instance = null;
    public static ChoosingObjectsInputSheet Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public override void OnWork()
    {
        RaycastCheck();
        MouseCheck();

        if (Input.GetKeyDown(KeyCode.Delete))
            DeleteObject();

    }
    const float mouse_click_room = 5;

    bool if_hit_object = false;
    bool if_hit_interference_plane = false;

    RaycastHit interference_plane_hit;

    Transform current_obj = null;
    string obj_type = "";

    void RaycastCheck()
    {
        
        if_hit_interference_plane = false;
        foreach (RaycastHit hit in Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition)))
        {
            if (hit.transform.tag != "InterferencePlane")
                continue;

            interference_plane_hit = hit;
            if_hit_interference_plane = true;
            return;
        }
    }
    void MouseCheck()
    {
        if (is_mouse_pressed)
            OnMouseHoldEvent();

        if (is_mouse_drag)
            OnMouseDragEvent();

        if (Input.GetMouseButtonDown(0))
            OnMouseDownEvent();

        if (Input.GetMouseButtonUp(0))
            OnMouseUpEvent();

        if (Input.GetMouseButton(0))
            OnMouseHoldEvent();

    }
    bool is_mouse_pressed = false;
    bool is_mouse_drag = false;
    private void OnMouseDownEvent()
    {
        is_mouse_pressed = true;
        mouse_down_pos = Input.mousePosition;

        foreach (RaycastHit hit in Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition)))
        {
            switch(hit.transform.tag)
            {
                case "Emitter":
                    if_hit_object = true;
                    current_obj = hit.transform;
                    obj_type = hit.transform.tag;

                    return;
                case "EmittersArray":
                    if_hit_object = true;
                    current_obj = hit.transform;
                    obj_type = hit.transform.tag;

                    return;
                default:
                    break;
            }
        }
    }
    private void OnMouseUpEvent()
    {
        
        if (Vector3.Distance(mouse_pos, mouse_down_pos) <= mouse_click_room)
            OnMouseClickEvent();

        is_mouse_pressed = false;

        if (is_mouse_drag)
            OnMouseDragEndEvent();

        if (if_hit_object)
            current_obj = null;

        if_hit_object = false;
    }
    private void OnMouseClickEvent()
    {
        if (if_hit_object)
            current_obj.GetComponent<IUIInteractable>().CreateUIWindow();
    }
    private void OnMouseHoldEvent()
    {
        mouse_pos = Input.mousePosition;

        if (is_mouse_drag == false)
            if (Vector3.Distance(mouse_pos, mouse_down_pos) > mouse_click_room)
                OnMouseDragBeginEvent();
    }
    private void OnMouseDragBeginEvent()
    {
        is_mouse_drag = true;
    }
    private void OnMouseDragEvent()
    {
        Debug.Log(interference_plane_hit.point.x +"        "+interference_plane_hit.point.z);

        if (if_hit_interference_plane && if_hit_object)
        {
            current_obj.position = new Vector3(interference_plane_hit.point.x, 0, interference_plane_hit.point.z);
            SimulationController.Instance.OnChange();
        }
    }
    private void OnMouseDragEndEvent()
    {
        is_mouse_drag = false;
    }
    void DeleteObject()
    {
        if (!if_hit_object)
            return;

        if (obj_type == "Emitter")
        {
            EmittersPool.PlaceEmitter(current_obj);
            if_hit_object = false;
            current_obj = null;
            obj_type = "";

            SimulationController.Instance.OnChange();
        }
        
    }
    
    Vector2 mouse_pos = Vector2.zero;
    Vector2 mouse_down_pos = Vector2.zero;
    
    public override void OnActivate()
    {
        SimulationController.Instance.OnChange();
        OnDeactivate();
    }

    public override void OnDeactivate()
    {
        is_mouse_pressed = false;
        is_mouse_drag = false;
        if_hit_object = false;
        if_hit_interference_plane = false;
        current_obj = null;
        obj_type = "";
    }
}
