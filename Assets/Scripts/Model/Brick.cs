using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject brickSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.transform.name;
        Debug.Log("destroy brick");
        Debug.Log(collisionName);
        if (collisionName.Equals("BallSprite"))
        {
            Destroy(brickSprite);
        }
    }
}
