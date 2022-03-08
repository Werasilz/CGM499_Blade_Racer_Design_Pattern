using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControl : Observer
{
    private bool _isTurboOn;
    private float _currentHealth;
    private BikeControl _bikeControl;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health : " + _currentHealth);
        GUILayout.EndHorizontal();

        if (_isTurboOn)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Turbo Activated!");
            GUILayout.EndHorizontal();
        }

        if (_currentHealth <= 50)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WARNING : Low Health");
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }

    public override void Notify(Subject subject)
    {
        if (!_bikeControl) _bikeControl = subject.GetComponent<BikeControl>();

        if (_bikeControl)
        {
            _isTurboOn = _bikeControl.IsTurboOn;
            _currentHealth = _bikeControl.CurrentHealth;
        }
    }
}
