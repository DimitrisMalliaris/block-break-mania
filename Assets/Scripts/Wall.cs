using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] bool playerLosesOnCollision = false;
    [SerializeField] Vector2 ballVelocityChange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
        {
            if (playerLosesOnCollision)
            {
                GameManager.Instance.OnDefeat();
                return;
            }

            Vector2 velocityChange = new Vector2(ballVelocityChange.x, ballVelocityChange.y);

            if (collision.rigidbody.velocity.x < 0)
                velocityChange.x *= -1;

            if (collision.rigidbody.velocity.y < 0)
                velocityChange.y *= -1;

            collision.rigidbody.AddForce(velocityChange);
        }
    }
}
