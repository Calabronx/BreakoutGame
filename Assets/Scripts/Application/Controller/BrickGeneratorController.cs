using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGeneratorController : MonoBehaviour
{
    [SerializeField] BrickView brickViewPrefab;
    [SerializeField] Brick brickInstance;
    private int rows = 12;
    private int columns = 9;
    private float xOffset = 6f;
    private float yOffset = 2f;
    private int rotation = 90;
    private int brickCounter = 0;
    [SerializeField] Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float xPosition = col * xOffset - ((columns - 1) * xOffset / 2);
                float yPosition = row * yOffset + 2.5f;
                BrickView brickView = Instantiate(brickViewPrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.Euler(0, 0, rotation));
                brickView.SetColor(Color.red);
                brickCounter++; // set the color of the brick view
            }
        }
    }
}
