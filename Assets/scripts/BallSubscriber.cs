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
        float grid_weight = 800F;
        float grid_height = 800F;

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
            float posX = (float)ball.position.x*grid_weight/2;
            float posY = (float)ball.position.y*grid_height/2;

            float CenterX = grid_weight/2;
            float CenterY = grid_height/2;
            ballRect.anchoredPosition = new Vector2(posX + CenterX, posY + CenterY);
            activePoints.Add(newBall);
        }
    }
}
