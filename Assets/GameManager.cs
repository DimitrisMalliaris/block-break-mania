using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Color[] BlockColors;
    [SerializeField] int blockCount = 0;
    [SerializeField] HealthUI healthUI;
    [SerializeField] GameObject victoryUI;
    [SerializeField] GameObject defeatUI;
    public bool HasStarted = false;
    public bool GamePaused = false;
    public int PlayerHealth = 3;

    private void Awake()
    {
        GameManager.Instance = this;
    }

    public void OnPlayerReset()
    {
        Ball ball = FindObjectOfType<Ball>();
        Player player = FindObjectOfType<Player>();

        HasStarted = false;
        ball.BallStop();
        ball.transform.parent = player.transform;
        ball.transform.position = player.transform.position + player.ballOffset;
    }

    public void OnBlockCreated()
    {
        blockCount++;
    }

    public void OnBlockDestroyed()
    {
        blockCount--;

        if(blockCount <= 0)
        {
            StartCoroutine(nameof(VictorySequence));
        }
    }

    public void OnDefeat()
    {
        StartCoroutine(nameof(DefeatSequence));
    }

    private IEnumerator VictorySequence()
    {
        victoryUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        // move to next level
    }

    private IEnumerator DefeatSequence()
    {
        PlayerHealth--;
        if(PlayerHealth >= 0)
        {
            PauseGame();
            healthUI.OnPlayerLoseHealth();
            OnPlayerReset();
            defeatUI.SetActive(true);
            yield return new WaitForSeconds(2f);
            defeatUI.SetActive(false);
            StartCoroutine(nameof(RoundStartSequence));
            UnpauseGame();
        }
        else
        {
            PauseGame();
            OnPlayerReset();
            defeatUI.SetActive(true);
            // return to main menu
        }
        
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator RoundStartSequence()
    {
        Debug.Log(3);
        yield return new WaitForSeconds(1f);
        Debug.Log(2);
        yield return new WaitForSeconds(1f);
        Debug.Log(1);
        yield return new WaitForSeconds(1f);
        Debug.Log("Start");
    }

    private void PauseGame()
    {
        GamePaused = true;
    }

    private void UnpauseGame()
    {
        GamePaused = false;
    }
}
