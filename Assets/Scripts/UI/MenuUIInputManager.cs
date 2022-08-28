using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIInputManager : MonoBehaviour
{
    void KeyboardInputIteration()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UIController.Instance.OpenMainUI();
    }
    public void Update()
    {
        KeyboardInputIteration();
    }
}
