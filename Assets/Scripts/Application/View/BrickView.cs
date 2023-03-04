using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickView : MonoBehaviour
{
    public SpriteRenderer brickRenderer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        brickRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetColor(Color color)
    {
        brickRenderer.color = color;
    }
}
