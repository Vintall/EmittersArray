using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingObjectsInputSheet : InputSheet
{
    public override void OnWork()
    {
        RaycastCheck();

        if (Input.GetKeyDown(KeyCode.Escape))
            CancelCreating();
    }
    void CancelCreating() => InterferencePlaneInteractionController.Instance.CancelCreating();

    RaycastHit raycast_hit;
    private void RaycastCheck() // Raycast from camera to mouse
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast_hit))
            return;

        if (raycast_hit.transform.tag == "InterferencePlane")
            OnMouseOnInterferencePlane(raycast_hit.point);
    }
    void OnMouseOnInterferencePlane(Vector3 point)
    {
        InterferencePlaneInteractionController.Instance.OnMouseOnInterferencePlane(point);

        if (Input.GetMouseButtonDown(0))
            InterferencePlaneInteractionController.Instance.OnInterferencePlaneClick(point);
    }

    public override void OnActivate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        //throw new System.NotImplementedException();
    }
}
