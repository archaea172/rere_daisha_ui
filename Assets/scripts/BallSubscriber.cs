using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionArrayMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;

public class BallSubscriber : MonoBehaviour
{
    public GameObject ballPrefab;
    public RectTransform canvasRectTransform;
    private List<GameObject> activePoints = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallPositionArrayMsg>("ball_position_yolo", Callback);
        
    }

    void Callback(BallPositionArrayMsg rxdata)
    {
        Debug.Log($"Received {rxdata.balls.Length} balls.");
        
        foreach (var point in activePoints)
        {
            Destroy(point);
        }
        activePoints.Clear();

        foreach (var ball in rxdata.balls)
        {
            GameObject newBall = Instantiate(ballPrefab, canvasRectTransform);

            RectTransform ballRect = newBall.GetComponent<RectTransform>();
            float posX = (float)ball.position.x;
            float posY = (float)ball.position.y;

            float CenterX = 502.2F;
            float CenterY = 500F;
            ballRect.anchoredPosition = new Vector2(posX + CenterX, posY + CenterY);
            activePoints.Add(newBall);
        }
    }
}
