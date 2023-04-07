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

    private bool isRespawning = false;

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
        // newBall = ballView.ballSprite;
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
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";

        if (!ballView.ballSprite.activeSelf)
        {
            gameView.continueMessageView.text = gameView.continueGameMsg;
        }
        else
        {
            gameView.continueMessageView.text = "";
        }

        if (Input.GetMouseButtonDown(0) && isRespawning)
        {

            respawnBall();

        }
        Debug.Log("is respawning " + isRespawning);
    }

    public void OnBallDeath()
    {
        numBallsDied++;

        if (ballInstance.Lifes > 0)
        {
            ballInstance.Lifes--;
            Debug.Log("respawn");
            DesactivateBall();
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

    public void DesactivateBall()
    {
        ballView.ballSprite.gameObject.SetActive(false);
        isRespawning = true;
    }

    // private IEnumerator resetBallPosition(GameObject ballReference)
    // {
    //     // ballView.ballSprite.gameObject.transform.position = new Vector2(0.05f, -2.2f);
    //     Debug.Log("waiting...");
    //     ballView.ballSprite.gameObject.SetActive(false);
    //     yield return new WaitForSeconds(3f);

    //     Debug.Log("run");
    //     ballView.ballSprite.gameObject.SetActive(true);
    //     ballView.ballSprite.gameObject.transform.position = new Vector2(0.05f, -2.2f);
    //     Rigidbody2D rigidbody2D = ballView.ballSprite.GetComponent<Rigidbody2D>();
    //     rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;

    //     // GameObject respawnBall = Instantiate(ballReference, new Vector2(0.05f, -2.2f), Quaternion.identity);
    //     // Destroy(ballView.ballSprite);
    // }
    private void respawnBall()
    {
        Debug.Log("reset ball");
        ballView.ballSprite.gameObject.SetActive(true);
        ballView.ballSprite.gameObject.transform.position = new Vector2(0.05f, -2.2f);
        Rigidbody2D rigidbody2D = ballView.ballSprite.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;
        isRespawning = false;
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
