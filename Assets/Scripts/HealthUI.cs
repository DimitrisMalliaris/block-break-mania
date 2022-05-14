using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject healthPrefab;
    void Start()
    {
        int playerHealth = GameManager.Instance.PlayerHealth;
        for (int i = 0; i < playerHealth; i++)
        {
            OnPlayerGainsHealth();
        }
    }

    public void OnPlayerLoseHealth()
    {
        Destroy(transform.GetChild(0).gameObject);
    }

    public void OnPlayerGainsHealth()
    {
        Instantiate(healthPrefab, transform);
    }
}
