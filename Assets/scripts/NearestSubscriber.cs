using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionMsg = RosMessageTypes.RereDaisha.BallPositionMsg;
using UnityEngine.UI;

public class RansacSubscriber : MonoBehaviour
{
    public RectTransform ballMarker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallPositionMsg>("/nearest_ball_position", Callback);
    }
    void Callback(BallPositionMsg rxdata)
    {
        float grid_weight = 800F;
        float grid_height = 800F;

        foreach (var point in activePoints)
        {
            Destroy(point);
        }
        activePoints.Clear();

        foreach (var ball in rxdata.points)
        {
            GameObject newBall = Instantiate(ballPrefab, canvasRectTransform);

            Image ballImage = newBall.GetComponent<Image>();
            ballImage.color = Color.black;
            RectTransform ballRect = newBall.GetComponent<RectTransform>();
            float posX = (float)ball.x * grid_weight / 2;
            float posY = (float)ball.y * grid_height / 2;

            float CenterX = grid_weight / 2;
            float CenterY = grid_height / 2;
            ballRect.anchoredPosition = new Vector2(posX + CenterX, posY + CenterY);
            activePoints.Add(newBall);
        }
    }
}
