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
    [SerializeField] BrickController bricksController;
    [SerializeField] RestartGame restartGame;
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] MainMenu menu;
    [SerializeField] HighScore finalHighScore;
    [SerializeField] GameObject game;
    [SerializeField] WinScreen winScreen;

    private bool isRespawning = false;
    public bool winGame = false;

    public bool looseGame = false;

    private void Awake()
    {
        // menu.Setup();
        gameView.lifesText.text = gameView.lifesScore + " " + ballInstance.Lifes + " HP";

    }
    private void Start()
    {
        //lifesText.text = lifesScore;
        // Debug.Log("bricks counter: " + gameBricks.BricksCounter);
    }
    private void Update()
    {
        // if(!menu.isActiveAndEnabled) {
        //     ballSprite.SetActive(true);
        // }
        Debug.Log("bricks counter: " + gameBricks.brickCounter);
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
        // if (winGame || looseGame)
        // {
        //     restart();
        // }
        if (gameBricks.brickCounter <= 0)
        {
            OnWin();
        }
        // Debug.Log("Total points: " + finalHighScore.playerPoints);
        // Debug.Log("Total bricks destroyed: " + finalHighScore.destroyedBricksCount);
        gameView.totalPoints.text = gameView.totalPointsMsg + finalHighScore.playerPoints;
        gameView.totalBricksDestroyed.text = gameView.totalBricksDestroyedMsg + finalHighScore.destroyedBricksCount;
        
    }

    // private void restart()
    // {
    //     if (Input.GetKeyDown(KeyCode.Return))
    //     {
    //         Debug.Log("pressed");
    //         StartCoroutine(ReloadScene());
    //         gameOverScreen.Desactivate();
    //     }
    //     else if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         Debug.Log("Quit game..");
    //         Application.Quit();
    //     }
    // }

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

        // if (gameBricks.brickCounter <= 0)
        // {
        //     OnWin();
        // }
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
            // gameView.winMessage.text = "Felicidades, ganaste! Para volver a jugar presione la tecla Enter para continuar o Espacio para salir";

            winGame = true;
            game.SetActive(false);
            winScreen.Setup();
        }
        else
        {
            Debug.Log("Sorry, you lose!");
            gameView.loseMessage.text = "GAME OVER - Reiniciar ? Presione la tecla Enter para continuar o Espacio para salir";
            // gameView.totalPoints.text = "Total points: " + finalHighScore.playerPoints;
            // gameView.totalBricksDestroyed.text = "Total bricks destroyed: " + finalHighScore.destroyedBricksCount;
            gameOverScreen.Setup();
            // gameView.restartGameQuestion.text = "Presione la tecla Enter para continuar o Espacio para salir";
            Destroy(ballView.ballSprite);
            looseGame = true;
            game.SetActive(false);
            // Application.Quit();
        }

    }

}
