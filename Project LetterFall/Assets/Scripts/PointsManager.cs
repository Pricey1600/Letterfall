using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int playerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void addPoints(int points)
    {
        playerScore += points;
    }

    public void removePoints(int points)
    {
        playerScore -= points;
    }
}
