using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public PlayerController controller;
    public E_Delegates delegateType;

    public GameObject showElement;

    private void Start()
    {
        switch (delegateType)
        {
            case E_Delegates.move:
                controller.move += Show;
                break;
            case E_Delegates.land:
                controller.land += Show;
                break;
            default:
                break;
        }
    }

    void Show()
    {
        showElement.SetActive(true);
    }
}

public enum E_Delegates
{
    move, land
}