using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (_isRecording)
        {
            _recordedCommands.Add(_recordingTime, command);

            Debug.Log("Recorded Time : " + _recordingTime);
            Debug.Log("Recorded Command : " + command);
        }
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;

        if (_recordedCommands.Count <= 0)
        {
            Debug.LogError("No Command to replay");
        }

        _recordedCommands.Reverse();
    }

    private void FixedUpdate()
    {
        if (_isRecording)
        {
            _recordingTime += Time.deltaTime;
        }

        if (_isReplaying)
        {
            _replayTime += Time.deltaTime;

            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time : " + _replayTime);
                    Debug.Log("Replay Command : " + _recordedCommands.Values[0]);

                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}