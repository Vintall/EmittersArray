using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Player camera
/// </summary>
public class FreeCam : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float fastMovementSpeed = 100f;
    public float freeLookSensitivity = 3f;
    bool fast_mode = false;

    public void OnMoveForward() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * transform.forward * Time.deltaTime;
    public void OnMoveBack() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * -transform.forward * Time.deltaTime;
    public void OnMoveLeft() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * -transform.right * Time.deltaTime;
    public void OnMoveRight() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * transform.right * Time.deltaTime;
    public void OnMoveUp() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * Vector3.up * Time.deltaTime;
    public void OnMoveDown() => transform.position += (fast_mode ? fastMovementSpeed : movementSpeed) * Vector3.down * Time.deltaTime;
    public void OnCheckBoost() => fast_mode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    public void OnStartLooking()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnStopLooking()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnLooking()
    {
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
    }
}