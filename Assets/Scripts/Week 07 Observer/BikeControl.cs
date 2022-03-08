using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : Subject
{
    public bool IsTurboOn { get; private set; }

    public float CurrentHealth { get { return health; } }

    private bool _isEndingOn;
    private HUDControl _hudControl;
    private CameraController _cameraController;

    [SerializeField]
    private float health = 100f;

    private void Awake()
    {
        _hudControl = gameObject.AddComponent<HUDControl>();
        _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
    }

    private void Start()
    {
        StartEngine();
    }

    private void OnEnable()
    {
        if (_hudControl) Attach(_hudControl);

        if (_cameraController) Attach(_cameraController);
    }

    private void OnDisable()
    {
        if (_hudControl) Detach(_hudControl);

        if (_cameraController) Detach(_cameraController);
    }

    private void StartEngine()
    {
        _isEndingOn = true;
        NotifyObservers();
    }

    public void ToggleTurbo()
    {
        if (_isEndingOn) IsTurboOn = !IsTurboOn;

        NotifyObservers();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        IsTurboOn = false;
        NotifyObservers();

        if (health < 0) Destroy(gameObject);
    }
}
