using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI BestScoreText;
    [SerializeField] TextMeshProUGUI LivesText;
    [SerializeField] GameObject gameOverScreen;

    public int Score { get; private set; }
    public int highScoreCount;
    public int Lives { get; private set; }

    public bool isGameOver;

    void Start()
    {
        Lives = 3;
        Score = 0;

        if (PlayerPrefs.HasKey("BestScore"))
        {
            highScoreCount = PlayerPrefs.GetInt("BestScore");
        }
        BestScoreText.text = "Best Score: " + highScoreCount.ToString();
    }

    public void UpdateScore(int ScorePointsToAdd)
    {
        Score += ScorePointsToAdd; 
        if (Score > highScoreCount)
        {
            highScoreCount = Score;
            PlayerPrefs.SetInt("BestScore", highScoreCount);
        }
        ScoreText.text = Score.ToString();  
        BestScoreText.text = "Best Score: " + highScoreCount.ToString();
            
    }


    public void RemainingLives()
    {
        if (isGameOver == false)
        {
            Lives--;
            LivesText.text = "LIVES : " + Lives;
            if (Lives == 0)
            {
                GameOver();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayMusic("Theme");

    }

    public void GameOver()
    {
        isGameOver = true;
        Invoke("ShowGameOverScreen", 2f);
        AudioManager.instance.musicSource.Stop();
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

}
