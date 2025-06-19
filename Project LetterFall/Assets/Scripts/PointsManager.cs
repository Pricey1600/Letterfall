using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText, gameOverScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void addPoints(int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();
        gameOverScoreText.text = playerScore.ToString();
    }

    public void removePoints(int points)
    {
        playerScore -= points;
        gameOverScoreText.text = playerScore.ToString();
    }
}
