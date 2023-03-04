using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Ball ballInstance;

    [SerializeField] GameObject ballSprite;

    public bool isDead = false;

    [SerializeField] new Rigidbody2D rigidbody2D;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
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
            die(ballSprite);
            ballInstance.lifes--;
            isDead = true;
            Debug.Log("YOU LOSE THE GAME");
            
        }
    }

    private void die(GameObject gameSprite)
    {
        Destroy(gameSprite);
    }

}
