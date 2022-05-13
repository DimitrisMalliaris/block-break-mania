using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int BlockHealth = 1;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        if(GameManager.Instance)
        {
            GameManager.Instance.OnBlockCreated();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.BlockColors[BlockHealth-1];
    }

    private void OnDestroy()
    {
        if(GameManager.Instance)
        {
            GameManager.Instance.OnBlockDestroyed();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        BlockHealth--;
        if (BlockHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.color = GameManager.Instance.BlockColors[BlockHealth - 1];
        }
    }
}
