using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
            HandleHit(ball);
    }

    private void HandleHit(Ball ball)
    {
        Ball newBall = Instantiate(ball);
        //newBall.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity;
        newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 5f);
    }
}
