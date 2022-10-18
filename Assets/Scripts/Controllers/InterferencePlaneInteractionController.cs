using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencePlaneInteractionController : MonoBehaviour
{
    [SerializeField] Transform creation_pointer;
    static float pointer_size = 1 / 80f; // relation of "pointer size" and "distance between pointer and cam"
    static InterferencePlaneInteractionController instance;
    public static InterferencePlaneInteractionController Instance => instance;
    private void Awake() => instance = this;

    string object_name;
    public string ObjectName => object_name;
    bool is_creating = false;
    public void StartCreating(string object_name)
    {
        creation_pointer.gameObject.SetActive(true);
        this.object_name = object_name;
        is_creating = true;
        InputController.Instance.GoToActionPattern("Creating Objects");
    }
    public void EndCreating()
    {
        if (!is_creating)
            return;

        creation_pointer.gameObject.SetActive(false);
        is_creating = false;
        object_name = "";

        InputController.Instance.GoToActionPattern("Main UI");
    }
    public void CancelCreating()
    {
        creation_pointer.gameObject.SetActive(false);
        is_creating = false;
        object_name = "";

        InputController.Instance.GoToActionPattern("Main UI");
    }
    public void OnMouseOnInterferencePlane(Vector3 point)
    {//On Creating
        creation_pointer.SetPositionAndRotation(new Vector3(point.x, 0, point.z), Quaternion.identity);
        float distance = Vector3.Distance(Camera.main.transform.position, point);
        creation_pointer.localScale = new Vector3(pointer_size * distance, pointer_size * distance, pointer_size * distance);
    }
    public void OnInterferencePlaneClick(Vector3 point)
    {//On Creating
        Transform obj = null;

        switch (object_name)
        {
            case "Emitter":
                obj = EmittersPool.TakeEmitter();
                break;
            case "Emitters Array":

                break;
        }

        if (obj == null)
            return;

        obj.position = new Vector3(point.x, 0, point.z);
        obj.GetComponent<IUIInteractable>().CreateUIWindow();

        EndCreating();
    }

    private void Update()
    {
        
    }
    
}
