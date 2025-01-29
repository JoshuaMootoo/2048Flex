using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridSystem : MonoBehaviour
{
    [Range(4, 10)]
    public int gridWidth;
    [Range(4, 10)]
    public int gridHeight;

    private int[,] grid;

    private void Start()
    {
        InitializeGrid();
        SpawnRandomTile();
        SpawnRandomTile();
        PrintGrid();
        
    }

    void InitializeGrid ()
    {
        grid = new int[gridWidth, gridHeight]; 

        // This fills the grid with "0" which means the tiles are empty.
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = 0;
            }
        }
    }

    void SpawnRandomTile ()
    {
        List<Vector2Int> emptyCells = new List<Vector2Int>();

        for (int x = 0;x < gridWidth; x++)
        {
            for (int y = 0;y < gridHeight; y++)
            {
                if (grid[x,y] == 0)
                {
                    emptyCells.Add(new Vector2Int(x, y));
                }
            }
        }

        if (emptyCells.Count > 0)
        {
            Vector2Int ramdomCell = emptyCells[Random.Range(0, emptyCells.Count)];
            grid[ramdomCell.x, ramdomCell.y] = (Random.value < 0.9f) ? 2 : 4; // this sets a 90% chance of the new tile being a 2 and a 10% chance of it being a 4
        }
    }

    void PrintGrid ()
    {
        string gridString = "";
        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for(int x = 0; x < gridWidth; x++)
            {
                gridString += grid[x, y].ToString().PadRight(5);
            }
            gridString += "\n";
        }
        Debug.Log(gridString);
    }
}
