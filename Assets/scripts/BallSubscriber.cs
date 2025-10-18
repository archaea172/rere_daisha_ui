using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.RereDaisha;

public class BallSubscriber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallArrayMsg>("ball_array_topic", Callback);
    }

    // Update is called once per frame
    void Callback(BallArrayMsg rxdata)
    {
        Debug.Log($"Received {message.balls.Length} balls.");
    }
}
