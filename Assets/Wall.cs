using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] bool playerLosesOnCollision = false;
    [SerializeField] Vector2 ballVelocityChange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            if (playerLosesOnCollision)
            {
                GameManager.Instance.OnDefeat();
                return;
            }

            collision.rigidbody.AddForce(ballVelocityChange);
            
        }
    }
}
