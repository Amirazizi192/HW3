using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;        // Score لحظه‌ای در بالا سمت چپ
    public TMP_Text bestScoreText;    // Best Score لحظه‌ای در بالا سمت چپ
    public GameObject gameOverPanel;  // Panel Game Over
    public TMP_Text finalScoreText;   // Score بعد از Game Over
    public TMP_Text finalBestScoreText; // Best بعد از Game Over

    void Start()
    {
        gameOverPanel.SetActive(false); // ابتدا پنهان
    }

    void Update()
    {
        // نمایش Score و Best Score زنده
        scoreText.text = "Score: " + GameManager.instance.score;
        bestScoreText.text = "Best: " + GameManager.instance.bestScore;

        // وقتی Game Over شد، Panel نمایش داده بشه
        if (GameManager.instance.isGameOver)
        {
            gameOverPanel.SetActive(true);

            // نمایش رکورد ها روی Panel
            finalScoreText.text = "Score: " + GameManager.instance.score;
            finalBestScoreText.text = "Best: " + GameManager.instance.bestScore;
        }
    }
}
