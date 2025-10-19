using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionArrayMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;
using UnityEngine.UI;
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
        Color[] labels = { Color.blue, Color.red, Color.yellow };

        foreach (var point in activePoints)
        {
            Destroy(point);
        }
        activePoints.Clear();

        foreach (var ball in rxdata.balls)
        {
            GameObject newBall = Instantiate(ballPrefab, canvasRectTransform);

            Image ballImage = newBall.GetComponent<Image>();
            ballImage.color = labels[ball.class_id];
            RectTransform ballRect = newBall.GetComponent<RectTransform>();
            float posX = (float)ball.position.x*500;
            float posY = (float)ball.position.y*500;

            float CenterX = 502.2F;
            float CenterY = 500F;
            ballRect.anchoredPosition = new Vector2(posX + CenterX, posY + CenterY);
            activePoints.Add(newBall);
        }
    }
}
