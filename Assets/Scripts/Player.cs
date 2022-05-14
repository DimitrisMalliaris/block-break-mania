using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] float startPower = 500f;
    public Vector3 ballOffset = new Vector2(0f, 0.4f);
    [SerializeField] float movingAreaLength = 16.4f;
    [SerializeField] bool autoplay = false;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GamePaused)
            return;

        if (!autoplay)
            HandleMovement();
        else
            AutoplayMovement();

        HandleLeftClick();
    }

    private void AutoplayMovement()
    {
        float newPosX;
        var ballPosition = ball.transform.position;
        if (ballPosition.x >= 0)
        {
            newPosX = Mathf.Min(ballPosition.x, movingAreaLength / 2);
        }
        else
        {
            newPosX = Mathf.Max(ballPosition.x, -movingAreaLength / 2);
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(newPosX, transform.position.y), 100f * Time.deltaTime);
    }

    void HandleMovement()
    {
        float newPosX;
        var mousePos = Input.mousePosition;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mouseWorldPos.x >= 0)
        {
            newPosX = Mathf.Min(mouseWorldPos.x, movingAreaLength / 2);
        }
        else
        {
            newPosX = Mathf.Max(mouseWorldPos.x, -movingAreaLength / 2);
        }

        //rigidbody.MovePosition(new Vector2(newPosX, transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(newPosX, transform.position.y), 100f * Time.deltaTime);
    }

    void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.HasStarted)
        {
            ball.BallStart(startPower);
            GameManager.Instance.HasStarted = true;
        }
    }
}
