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

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartLooking();

        if (Input.GetMouseButtonUp(1))
            StopLooking();

        if (!Input.GetMouseButton(1))
            return;


        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

        if (Input.GetKey(PreferencesController.Instance.MoveLeft))
        {
            transform.position += -transform.right * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(PreferencesController.Instance.MoveRight))
        {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(PreferencesController.Instance.MoveForward))
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(PreferencesController.Instance.MoveBack))
        {
            transform.position += -transform.forward * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }

        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;

        
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
    }

    public void StartLooking()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StopLooking()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}