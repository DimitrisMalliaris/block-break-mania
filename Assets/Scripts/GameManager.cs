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
    [SerializeField, Range(0f, 10f)] float timeScale = 1f;
    [SerializeField, Range(0f, 1f)] float slowMoFactor = 0.75f;
    float slowMoTime = 0f;
    [SerializeField] AudioClip mainTheme;
    [SerializeField] AudioClip victorySound;
    [SerializeField] AudioClip defeatSound;
    [SerializeField] AudioClip pauseSound;
    [SerializeField] AudioClip unpauseSound;

    public AudioSource AudioSource;

    private void Awake()
    {
        GameManager.Instance = this;
        AudioSource = GetComponent<AudioSource>();
        AudioSource.PlayOneShot(mainTheme);
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

    private void Update()
    {
        if (slowMoTime > Time.time)
            Time.timeScale = timeScale * slowMoFactor;
        else
            Time.timeScale = timeScale;
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
        AudioSource.PlayOneShot(victorySound);
        victoryUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        // move to next level
        GameSceneManager.Instance.LoadNextScene();
    }

    private IEnumerator DefeatSequence()
    {
        AudioSource.PlayOneShot(defeatSound);
        PlayerHealth--;
        if(PlayerHealth >= 0)
        {
            //PauseGame();
            healthUI.OnPlayerLoseHealth();
            OnPlayerReset();
            defeatUI.SetActive(true);
            yield return new WaitForSeconds(2f);
            defeatUI.SetActive(false);
            StartCoroutine(nameof(RoundStartSequence));
            //UnpauseGame();
        }
        else
        {
            //PauseGame();
            OnPlayerReset();
            defeatUI.SetActive(true);
            // return to main menu
            GameSceneManager.Instance.LoadMainMenu();
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
        AudioSource.PlayOneShot(pauseSound);
        GamePaused = true;
    }

    private void UnpauseGame()
    {
        AudioSource.PlayOneShot(unpauseSound);
        GamePaused = false;
    }

    public void ActivateSlowMo(float duration)
    {
        slowMoTime = Time.time + duration;
    }
}
