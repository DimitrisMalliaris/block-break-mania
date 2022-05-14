using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoOnHit : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.ActivateSlowMo(duration);
    }
}
