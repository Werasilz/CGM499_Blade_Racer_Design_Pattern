using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDoorHandler : MonoBehaviour
{
    public bool open = false;
    public bool isOpened = false;
    public int doorID;

    private void OnEnable()
    {
        ScriptTriggerEventManager.OpenDoorEvent += OpenDoor;
    }

    private void OnDisable()
    {
        ScriptTriggerEventManager.OpenDoorEvent -= OpenDoor;
    }

    private void OpenDoor(int triggerID)
    {
        if (triggerID == doorID)
        {
            open = true;
        }
    }

    private void Update()
    {
        if (isOpened == false && open == true)
        {
            isOpened = true;
            transform.position += Vector3.up * 5;
        }
    }
}
