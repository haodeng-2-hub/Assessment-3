using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timerText;
    public GameObject winPanel;
    public GameObject losePanel;

    private int score = 0;
    private int lives = 3;
    private float timer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimer();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void LoseLife()
    {
        lives--;
        UpdateLives();
        if (lives <= 0)
        {
            LoseGame();
        }
    }

    void UpdateUI()
    {
        UpdateScore();
        UpdateLives();
        UpdateTimer();
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "SCORE: " + score.ToString("00000");
    }

    void UpdateLives()
    {
        if (livesText != null)
            livesText.text = "LIVES: " + lives;
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = $"TIME: {minutes:00}:{seconds:00}";
        }
    }

    void WinGame()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    void LoseGame()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
