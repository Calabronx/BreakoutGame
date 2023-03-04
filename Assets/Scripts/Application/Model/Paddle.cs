using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int lifes = 5;
    public float movementSpeed = 5f;
    public float minX = -25.84f;
    public float maxX = 26.6f;
    public Vector2 currentVelocity;
    public Vector2 moveDirection;
}
