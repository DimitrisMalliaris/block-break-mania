using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float randomOffset = 3f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        BallStop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset)));
    }

    public void BallStart(float startPower)
    {
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(Vector2.up * startPower);
    }

    public void BallStop()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
    }
}
