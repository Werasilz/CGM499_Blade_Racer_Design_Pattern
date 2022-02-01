using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTriggerEventManager : MonoBehaviour
{
    public static event Action<int> OpenDoorEvent;

    public static void StartOpenDoorEvent(int id)
    {
        OpenDoorEvent?.Invoke(id);
    }
}
