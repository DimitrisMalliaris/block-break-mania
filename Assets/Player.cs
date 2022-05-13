using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float startPower = 1000f;
    [SerializeField] float movingAreaLength = 16.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        HandleLeftClick();
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

        transform.position = new Vector2(newPosX, transform.position.y);
    }

    void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ball.transform.parent = null;
            ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * startPower);
        }
    }
}
