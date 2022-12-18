using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenuPage : MonoBehaviour, IMenuPage
{
    public void ActivateGameObject()
    {
        gameObject.SetActive(true);
        LoadOnActivation();
    }

    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    public void LoadOnActivation()
    {
    }
}
