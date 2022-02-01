using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;

    public float CurrentSpeed { get; set; }

    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public Direction CurrentTurnDirection { get; private set; }

    private IBikeState _stopState, _startState, _turnState;

    private BikeStateContext _bikeStateContext;

    private string _status = "Stopped";

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }

    private void OnDisable()
    {
        RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
        RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
    }

    private void Start()
    {
        _bikeStateContext = new BikeStateContext(this);

        _stopState = gameObject.AddComponent<BikeStopState>();
        _startState = gameObject.AddComponent<BikeStartState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();

        _bikeStateContext.Transition(_stopState);
    }

    public void StartBike()
    {
        _bikeStateContext.Transition(_startState);

        _status = "Started";
    }

    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);

        _status = "Stopped";
    }

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;

        _bikeStateContext.Transition(_turnState);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
    }
}
