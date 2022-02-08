using UnityEngine;

public class ClientState : MonoBehaviour
{
    private BikeController _bikeController;

    private void Start()
    {
        _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start Bike"))
        {
            _bikeController.StartBike();
        }

        if (GUILayout.Button("Turn Left"))
        {
            _bikeController.Turn(BikeController.Direction.Left);
        }

        if (GUILayout.Button("Turn Right"))
        {
            _bikeController.Turn(BikeController.Direction.Right);
        }

        if (GUILayout.Button("Stop Bike"))
        {
            _bikeController.StopBike();
        }
    }
}