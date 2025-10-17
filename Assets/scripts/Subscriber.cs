using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;

// using BallMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;
using RosMessageTypes.Std;
public class Subscriber : MonoBehaviour
{

    void Start()
    {
        ROSConnection.instance.Subscribe<Int32Msg>("test", Callback);
    }

    void Callback(Int32Msg rxdata)
    {
        Debug.Log(rxdata.data);
    }
}
