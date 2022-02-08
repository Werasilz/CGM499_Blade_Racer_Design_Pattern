using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    private void Start()
    {
        // ToDoList : 
        // Load Player Save
        // If no save, redirect player to registration scene
        // Call backend and get daily challenge and rewards

        _sessionStartTime = DateTime.Now;
        Debug.Log("Game Session Start @: " + _sessionStartTime);
    }

    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;

        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game Session Ended @: " + _sessionEndTime);
        Debug.Log("Game Session Lasted " + timeDifference);
    }

    private void OnGUI()
    {
        // if (GUILayout.Button("Next Scene"))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }

        // if (GUILayout.Button("Back Scene"))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // }
    }
}
