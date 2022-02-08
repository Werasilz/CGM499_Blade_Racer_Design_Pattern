using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChangeSize : MonoBehaviour
{
    private void OnEnable()
    {
        ScriptEventManager.IncreasesSizeEvent += IncreaseSize;
        ScriptEventManager.DecreaseSizeEvent += DecreaseSize;
    }

    private void OnDisable()
    {
        ScriptEventManager.IncreasesSizeEvent -= IncreaseSize;
        ScriptEventManager.DecreaseSizeEvent -= DecreaseSize;
    }

    private void DecreaseSize()
    {
        transform.localScale *= 1.2f;
    }

    private void IncreaseSize()
    {
        transform.localScale *= 0.8f;
    }

}
