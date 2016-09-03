using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Phase phase = Phase.SCOUT;
    public Hex[,] grid;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void StartGame()
    {
        FogAllHexes();
        RevealHexes(grid.GetLength(0) / 2, grid.GetLength(1) / 2);
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case Phase.SCOUT:

                break;
            case Phase.PLACEMENT:

                break;
            case Phase.ALIGNMENT:

                break;
            case Phase.GROW:

                break;
        }
    }

    private void FogAllHexes()
    {
        foreach (Hex hex in grid)
        {
            hex.SetFog();
        }
    }

    public void RevealHexes(int row, int col)
    {
        if(row % 2 == 0)
        {
            // Top
            HighLightHex(row - 1, col - 1);
            HighLightHex(row - 1, col);
            // Middle
            HighLightHex(row, col - 1);
            HighLightHex(row, col);
            HighLightHex(row, col + 1);
            // Bottom
            HighLightHex(row + 1, col - 1);
            HighLightHex(row + 1, col);
        }
        else
        {
            // Top
            HighLightHex(row - 1, col );
            HighLightHex(row - 1, col+1);
            // Middle
            HighLightHex(row, col - 1);
            HighLightHex(row, col);
            HighLightHex(row, col + 1);
            // Bottom
            HighLightHex(row + 1, col );
            HighLightHex(row + 1, col+1);
        }
    }

    private void HighLightHex(int row, int col)
    {
        if (CheckWithinBounds(row, col))
        {
            grid[row, col].SetHighlight();
        }
    }

    private void HighlightAllHexes()
    {
        foreach (Hex hex in grid)
        {
            hex.SetHighlight();
        }
    }

    private bool CheckWithinBounds(int row, int col)
    {
        if (row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1))
        {
            return true;
        }

        return false;
    }

}
