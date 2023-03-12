using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Ball ballInstance;

    [SerializeField] BallView ballView;

    public bool isDead = false;

    [SerializeField] new Rigidbody2D rigidbody2D;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down * ballInstance.ballSpeed;
    }

    void FixedUpdate()
    {
        ballInstance.currentVelocity = rigidbody2D.velocity;
        if (ballInstance.ballSpeed < Ball.MIN_SPEED)
        {
            //ballInstance.ballSpeed = Ball.MIN_SPEED;
            rigidbody2D.velocity = ballInstance.moveDirection * ballInstance.ballSpeed;
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
            if (gameManager != null)
            {
                Debug.Log("die");
                gameManager.OnBallDeath();
            }
            else
            {
                Debug.LogWarning("GameManager not found.");
            }
        }
    }
}
