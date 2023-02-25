using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    // Update is called once per frame
    public Paddle paddleInstance;
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
    }

}
