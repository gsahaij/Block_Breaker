using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;                    // Object to be spawned
    private Transform spawnerParent;            // Holds the parent for all the blocks

    // Columns
    public int horizontalBlockAmount = 13;      // Number of blocks per row
    public int startingX = -6;                  // Where to place first block
    public float gap = 0.1f;                    // How far away to place each block on a row

    // Rows
    public int verticalBlockAmount = 5;         // Number of rows
    public int startingY = 4;                   // Where to place first block

    // Dimensions
    private float blockWidth;
    private float blockHeight;

    // Colours
    private Color[] colorsForBlocks = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };
    private int activeColor = 0;

    void Awake()
    {
        // Get the parent's transform (organizational purposes)
        spawnerParent = GetComponent<Transform>();

        // Get the dimensions of the block
        blockWidth = block.transform.localScale.x;
        blockHeight = block.transform.localScale.y;
    }
    void Start()
    {
        // Columns
        for(int i = 0; i < horizontalBlockAmount; i++)
        {
            // Rows
            for(int j = 0; j < verticalBlockAmount; j++)
            {
                if(activeColor >= 5) { activeColor = 0; }                                   // Reset colors if exceeded 4
                block.GetComponent<SpriteRenderer>().color = colorsForBlocks[activeColor];  // Change color of block
                activeColor++;                                                              // Increment color

                // Generate positions
                float xPos = (i + startingX) * (blockWidth + gap);
                float yPos = (j + startingY) * (blockHeight + gap);

                // Spawn the block at the new xPos and yPos under the spawnerParent
                Instantiate(block, new Vector3(xPos, yPos, 0), Quaternion.identity, spawnerParent);
            }
        }
    }
}
