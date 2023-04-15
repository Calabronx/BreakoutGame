using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numBallsDied = 0;
    [SerializeField] GameView gameView;
    [SerializeField] BallView ballView;
    [SerializeField] Ball ballInstance;
    [SerializeField] GameObject ballSprite;
    [SerializeField] BrickGeneratorController gameBricks;
    [SerializeField] RestartGame restartGame;

    private bool isRespawning = false;
    public bool winGame = false;

    public bool looseGame = false;

    private void Awake()
    {
        //lives = ballInstance.lifes;
        //lifesText.text = lifesScore + " " + ballInstance.lifes + " HP";
        // newBall = ballView.ballSprite;
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";
        // Debug.Log("bricks counter: " + gameBricks.brickCounter );
    }
    private void Start()
    {
        //lifesText.text = lifesScore;
        Debug.Log("bricks counter: " + gameBricks.BricksCounter);
    }
    private void Update()
    {
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";

        if (ballView.ballSprite != null)
        {
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
        }
        if (winGame || looseGame)
        {
            restart();
        }
    }

    private void restart()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("pressed");
            StartCoroutine(ReloadScene());
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit game..");
            Application.Quit();
        }
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
            looseGame = true;
        }

        if (gameBricks.BricksCounter <= 0)
        {
            OnWin();
        }
    }

    public void OnWin()
    {
        winGame = true;
        EndGame(true);
    }

    public void DesactivateBall()
    {
        ballView.ballSprite.gameObject.SetActive(false);
        isRespawning = true;
    }

    private IEnumerator ReloadScene()
    {
        Debug.Log("restarting");
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        winGame = false;
        looseGame = false;
    }
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
            winGame = true;
        }
        else
        {
            Debug.Log("Sorry, you lose!");
            gameView.loseMessage.text = "GAME OVER - Restart ? Presione la tecla Enter para continuar o Espacio para salir";
            // gameView.restartGameQuestion.text = "Presione la tecla Enter para continuar o Espacio para salir";
            Destroy(ballView.ballSprite);
            looseGame = true;
            // Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("pressed");
            StartCoroutine(ReloadScene());
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit game..");
            Application.Quit();
        }


        // StartCoroutine(ReloadScene());
        //reload scene or end game with app.exit(0)
    }


}
