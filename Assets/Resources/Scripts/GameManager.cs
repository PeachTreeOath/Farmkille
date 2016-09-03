using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public struct Key
    {
        public readonly int x;
        public readonly int y;
        public Key(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    public static GameManager instance;

    public Phase phase = Phase.SCOUT;
    public Dictionary<Key, Hex> grid;

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
        // RevealHexes(new  / 2, grid.GetLength(1) / 2);
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
        foreach (var key in grid.Keys)
        {
            grid[key].SetFog();
        }
    }

    public void RevealHexes(int x, int y, int z)
    {
        /*  if(row % 2 == 0)
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
          }*/
    }

    private void HighLightHex(int row, int col)
    {
        /*   if (CheckWithinBounds(row, col))
           {
               grid[row, col].SetHighlight();
           }*/
    }

    private void HighlightAllHexes()
    {
        foreach (var key in grid.Keys)
        {
            grid[key].SetHighlight();
        }
    }

    private bool CheckWithinBounds(int row, int col)
    {
        //  if (row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1))
        {
            return true;
            //  }

            //return false;
        }
    }
}
