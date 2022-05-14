using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefeatUI : MonoBehaviour
{
    [SerializeField] string loseRoundText = "1 Life lost!";
    [SerializeField] string gameOverText = "Game Over.";

    private void OnEnable()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = GetDisplayText();
    }

    string GetDisplayText()
    {
        return GameManager.Instance.PlayerHealth >= 0 ? loseRoundText : gameOverText;
    }
}
