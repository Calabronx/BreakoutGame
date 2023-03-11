using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int numBallsDied = 0;

    [SerializeField] BallView ballView;
    [SerializeField] Ball ballInstance;
    [SerializeField] GameObject ballSprite; // should be the gameEmpty,not sprite to be destroyed

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
    }
    public void OnBallDeath()
    {
        numBallsDied++;
        
        if (lives > 0)
        {
            lives--;
            Debug.Log("respawn");
            RespawnBall();
        }
        else
        {
            EndGame(false);
        }
    }

    public void OnWin()
    {
        EndGame(true);
    }

    public void RespawnBall()
    {
        Destroy(ballView.ballSprite);
        Destroy(ballInstance);
        Debug.Log("ball old name: " + ballView.ballSprite.name);
        GameObject newBall = Instantiate(ballView.ballSprite, new Vector2(0.05f, -2.2f), Quaternion.identity);
        newBall.name = "BallSprite";
        ballView = newBall.GetComponent<BallView>();
        BallController ballController = newBall.GetComponent<BallController>();
        ballController.enabled = true;
        CircleCollider2D circleCollider2D = newBall.GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
        Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;
        Debug.Log("ball new name: " + newBall);
    }
    // Start is called before the first frame update
    public void EndGame(bool win)
    {
        if (win)
        {
            Debug.Log("Congratulations, you win!");
        }
        else
        {
            Debug.Log("Sorry, you lose!");
        }
        //reload scene or end game with app.exit(0)
    }
}
