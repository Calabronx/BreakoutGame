using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Ball ballInstance;

    [SerializeField] BallView ballView;

    public bool isDead = false;

    private int lifeGame = 0;
    [SerializeField] new Rigidbody2D rigidbody2D;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        lifeGame = ballInstance.lifes;
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;

    }

    // Update is called once per frame
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.KeypadEnter)) {
        //     Instantiate(ballInstance,ballInstance.transform.position);
        // }
    }
    void FixedUpdate()
    {
        ballInstance.currentVelocity = rigidbody2D.velocity;
        if (ballInstance.ballSpeed < Ball.MIN_SPEED)
        {
            ballInstance.ballSpeed = Ball.MIN_SPEED;
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        string collisionName = collision.transform.name;

        ballInstance.moveDirection = Vector2.Reflect(ballInstance.currentVelocity, collision.GetContact(0).normal);
        rigidbody2D.velocity = ballInstance.moveDirection;
        if (collisionName.Equals("LowerLimit"))
        {
            //die(ballView.ballSprite);
            //isDead = true;
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) {
                Debug.Log("die");
                gameManager.OnBallDeath();
            } else {
                Debug.LogWarning("GameManager not found.");
            }
        }
    }

    private void die(GameObject gameSprite)
    {
        if (lifeGame <= 0)
        {
            Debug.Log("GAME OVER");
            Debug.Log("YOU LOSE THE GAME");
            Destroy(gameSprite);
        }
        else
        {
            Destroy(gameSprite);
            Debug.Log("-1 LIFE");
            lifeGame--;
            Debug.Log("Lifes: " + lifeGame);
            GameObject newBall = Instantiate(ballView.ballSprite, new Vector2(0.05f, -2.2f), Quaternion.identity);
            newBall.name = "BallSprite";
            BallController ballController = newBall.GetComponent<BallController>();
            ballController.enabled = true;
            CircleCollider2D circleCollider2D = newBall.GetComponent<CircleCollider2D>();
            circleCollider2D.enabled = true;
            Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;
        }
    }

}
