using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    public Ball ballInstance;

    public GameObject ballSprite;

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
    void FixedUpdate()
    {
        ballInstance.currentVelocity = rigidbody2D.velocity;
        //if(currentVelocity > 5) {
        //rigidbody2D.velocity =
        //}
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
        }
    }

    private void die(GameObject gameSprite)
    {
        Debug.Log("die");
        Destroy(gameSprite);
    }


}
