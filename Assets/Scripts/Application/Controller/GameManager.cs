using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] int numBallsDied = 0;
    [SerializeField] GameView gameView;
    [SerializeField] BallView ballView;
    [SerializeField] Ball ballInstance;
    [SerializeField] GameObject ballSprite; // should be the gameEmpty,not sprite to be destroyed

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        //lives = ballInstance.lifes;
        //lifesText.text = lifesScore + " " + ballInstance.lifes + " HP";
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";
    }
    private void Start()
    {
        //lifesText.text = lifesScore;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        //lifesText.text = lifesScore + " " + ballInstance.lifes + " HP";
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";
    }

    public void OnBallDeath()
    {
        numBallsDied++;
        
        if (ballInstance.Lifes > 0)
        {
            ballInstance.Lifes--;
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
        //Destroy(ballInstance);
        GameObject newBall = Instantiate(ballView.ballSprite.gameObject, new Vector2(0.05f, -2.2f), Quaternion.identity);
        newBall.name = "BallSprite";
        ballView.ballSprite = newBall;
        BallController ballController = newBall.GetComponent<BallController>();
        ballController.enabled = true;
        CircleCollider2D circleCollider2D = newBall.GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
        Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;
    }
    // Start is called before the first frame update
    public void EndGame(bool win)
    {
        if (win)
        {
            Debug.Log("Congratulations, you win!");
            gameView.winMessage.text = "Congratulations, you win!";
        }
        else
        {
            Debug.Log("Sorry, you lose!");
            gameView.loseMessage.text = "Sorry, you lose!";
            Destroy(ballView.ballSprite);
            Application.Quit();
        }
        //reload scene or end game with app.exit(0)
    }

    
}
