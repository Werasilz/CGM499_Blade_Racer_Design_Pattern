using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDoorTriggerHandler : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter(Collider other)
    {
        ScriptTriggerEventManager.StartOpenDoorEvent(triggerID);
    }
}
