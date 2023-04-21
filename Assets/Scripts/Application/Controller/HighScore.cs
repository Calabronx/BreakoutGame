using UnityEngine;

public class HighScore : MonoBehaviour
{
    public int playerPoints;
    public int destroyedBricksCount;

    public int bricksDestroyedCounter()
    {
        return destroyedBricksCount++;
    }
    public int playerPointsCounter()
    {
        return playerPoints += 2;
    }
}
