using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);
        }
    }
}
