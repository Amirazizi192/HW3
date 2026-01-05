using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public int score = 0;
    public int bestScore = 0;

    public float scorePerSecond = 1f; // واحد امتیاز در ثانیه
    private float scoreTimer = 0f;    // تایمر برای جمع کردن امتیاز

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Update()
    {
        if (isGameOver) return;

        // جمع کردن Time.deltaTime
        scoreTimer += Time.deltaTime * scorePerSecond;

        // وقتی تایمر >= 1 شد، امتیاز اضافه کن و تایمر کم کن
        if (scoreTimer >= 1f)
        {
            score += Mathf.FloorToInt(scoreTimer); // اضافه کردن بخش کامل تایمر
            scoreTimer -= Mathf.Floor(scoreTimer); // باقیمانده تایمر
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
}
