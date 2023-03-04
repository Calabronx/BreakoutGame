using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Brick brick;
    //[SerializeField] GameObject brick;

     private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.transform.name;
        
        Debug.Log(collisionName);
        if (collisionName.Equals("BallSprite"))
        {
            brick.health--;
            if(brick.health <= 0) {
                Debug.Log("destroy brick");
                brick.isDead = true;
                Destroy(brick.brickSprite);
            }
        }
    }
}
