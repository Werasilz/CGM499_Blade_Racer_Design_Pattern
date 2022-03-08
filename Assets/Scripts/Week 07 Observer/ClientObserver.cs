using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    private BikeControl _bikeControl;

    private void Start()
    {
        _bikeControl = (BikeControl)FindObjectOfType(typeof(BikeControl));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Damage Bike"))
        {
            if (_bikeControl) _bikeControl.TakeDamage(15f);
        }

        if (GUILayout.Button("Toggle Turbo"))
        {
            if (_bikeControl) _bikeControl.ToggleTurbo();
        }
    }
}
