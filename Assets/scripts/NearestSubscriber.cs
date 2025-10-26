using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionMsg = RosMessageTypes.RereDaisha.BallPositionMsg;
using UnityEngine.UI;

public class RansacSubscriber : MonoBehaviour
{
    public GameObject ballPrefab;
    public RectTransform canvasRectTransform;private List<GameObject> activeBalls = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallPositionMsg>("/nearest_ball_position", Callback);
    }
    void Callback(BallPositionMsg rxdata)
    {
        foreach (var ball in activeBalls)
        {
            Destroy(ball);
        }
        activeBalls.Clear();

        Color[] labels = { Color.blue, Color.red, Color.yellow };

        float grid_width = 800F;
        float grid_height = 800F;

        GameObject newBall = Instantiate(ballPrefab, canvasRectTransform);
        
        Image ballImage = newBall.GetComponent<Image>();
        ballImage.color = labels[rxdata.class_id];
        RectTransform ballRect = newBall.GetComponent<RectTransform>();

        float posX = (float)rxdata.position.x * grid_width / 2;
        float posY = (float)rxdata.position.y * grid_height / 2;

        float centerX = grid_width / 2;
        float centerY = grid_height / 2;

        ballRect.anchoredPosition = new Vector2(posX + centerX, posY + centerY);
        activeBalls.Add(newBall);
    }
}
