using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionArrayMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;

public class BallSubscriber : MonoBehaviour
{
    public RectTransform Ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallPositionArrayMsg>("ball_position_yolo", Callback);
        
    }

    void Callback(BallPositionArrayMsg rxdata)
    {
        Debug.Log($"Received {rxdata.balls.Length} balls.");
    }
}
