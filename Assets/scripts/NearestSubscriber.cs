using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using BallPositionMsg = RosMessageTypes.RereDaisha.BallPositionMsg;
using UnityEngine.UI;

public class RansacSubscriber : MonoBehaviour
{
    public GameObject ballPrefab;
    public RectTransform ballMarker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<BallPositionMsg>("/nearest_ball_position", Callback);
        ballMarker?.gameObject.SetActive(false);
    }
    void Callback(BallPositionMsg rxdata)
    {
        Color[] labels = { Color.blue, Color.red, Color.yellow };
        if (ballMarker == null)
        {
            return;
        }

        if (!ballMarker.gameObject.activeSelf)
        {
            ballMarker.gameObject.SetActive(true);
        }

        float grid_width = 800F;
        float grid_height = 800F;

        GameObject newBall = Instantiate(ballPrefab, ballMarker);
        
        Image ballImage = newBall.GetComponent<Image>();
        ballImage.color = labels[rxdata.class_id];
        RectTransform ballRect = newBall.GetComponent<RectTransform>();
        if (ballRect == null) return;

        float posX = (float)rxdata.position.x * grid_width / 2;
        float posY = (float)rxdata.position.y * grid_height / 2;

        float centerX = grid_width / 2;
        float centerY = grid_height / 2;
        ballRect.anchoredPosition = new Vector2(posX + centerX, posY + centerY);
    }
}
