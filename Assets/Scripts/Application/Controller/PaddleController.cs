using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] Paddle paddleInstance;

    [SerializeField] GameObject paddleSprite;
    [SerializeField] new Rigidbody2D rigidbody2D;

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * Vector3.right * paddleInstance.movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * Vector3.left * paddleInstance.movementSpeed;
        }
        float moveX = Input.GetAxis("Horizontal") * paddleInstance.movementSpeed * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + moveX, paddleInstance.minX, paddleInstance.maxX), transform.position.y);
    }


}
