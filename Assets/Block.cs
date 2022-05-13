using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static int BlockCount = 0;

    private void Start()
    {
        BlockCount++;
    }

    private void OnDestroy()
    {
        BlockCount--;
        if(BlockCount == 0)
        {
            Debug.Log("All blocks destroyed!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        Destroy(gameObject);
    }
}
