using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIInputManager : MonoBehaviour
{
    void KeyboardInputIteration()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UIController.Instance.OpenMenuUI();
    }
    public void Update()
    {
        KeyboardInputIteration();
    }
}
