using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionArrayMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;
using UnityEngine.UI;

public class RansacSubscriber : MonoBehaviour
{
    public GameObject ballPrefab;
    public RectTransform canvasRectTransform;
    private List<GameObject> activePoints = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
