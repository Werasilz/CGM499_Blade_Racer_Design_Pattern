using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float _currentTime;
    private float duration = 3f;

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    private void OnDisable()
    {
        RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    private void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        _currentTime = duration;

        while (_currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        RaceEventBus.Publish(RaceEventType.START);
    }

    private void OnGUI()
    {
        GUI.color = Color.blue;
        GUI.Label(new Rect(125, 0, 120, 20), "COUNTDOWN: " + _currentTime.ToString());
    }
}
