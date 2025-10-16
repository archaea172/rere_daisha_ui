using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;

using BallMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;
public class Subscriber : MonoBehaviour
{

    void Start()
    {
        ROSConnection.instance.Subscribe<BallMsg>("ball_position_yolo", Callback);
    }

    void Callback(BallMsg rxdata)
    {
        Debug.Log(rxdata.balls);
    }
}
