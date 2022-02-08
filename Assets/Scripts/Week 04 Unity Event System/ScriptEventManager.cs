using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEventManager : MonoBehaviour
{
    public static event Action IncreasesSizeEvent;
    public static event Action DecreaseSizeEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IncreasesSizeEvent?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DecreaseSizeEvent?.Invoke();
        }
    }
}
