using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private int lifes = 10;
    public float ballSpeed = 20f;
    public const float MIN_SPEED = 20f;
    public Vector2 currentVelocity;
    public Vector2 moveDirection;

    public int Lifes
    {
        get { return lifes; }
        set { lifes = value; }
    }


}
