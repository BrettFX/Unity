using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Ensure that block coordinates are rounded to prevent unwanted collisions
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    // Validate if a block is within the bounds of the boarder
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < width &&
                (int)pos.y >= 0);
    }

    // Delete all blocks in a specified row
    public static void deleteRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    // Pull rows from above down after deleting a row
    public static void decreaseRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    // Use the decreaseRow function and use it on every row above a certain index
    // because whenever a row was deleted, we want to decrease all rows above it, not just one
    public static void decreaseRowsAbove(int y)
    {
        // Traverse height of grid and decrease each row by one
        for (int i = y; i < height; i++)
            decreaseRow(i);
    }

    // Determine if a row is full of blocks
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; x++)
            // As soon as an empty block is found we know that the row isn't found
            if (grid[x, y] == null)
                return false;
        return true;
    }

    // Deletes all full rows and then always decreases the above row's y coordinate by one.
    public static void deleteFullRows()
    {
        for (int y = 0; y < height; y++)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);

                // Make sure that the next step of the for loop continues at the correct index
                // (which must be decreased by one, because we just deleted a row)
                y--;
            }
        }
    }
}
