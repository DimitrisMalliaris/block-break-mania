using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float randomOffset = 3f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rigidbody = GetComponent<Rigidbody2D>();
        BallStop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.AddForce(new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset)));
    }

    public void BallStart(float startPower)
    {
        transform.parent = null;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.AddForce(Vector2.up * startPower);
    }

    public void BallStop()
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
    }
}
