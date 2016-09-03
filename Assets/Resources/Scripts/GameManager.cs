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

    public int hexRadius;

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
        RevealHexes(0, 0);
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

    public void RevealHexes(int x, int y)
    {
        HighLightHex(x, y);
        HighLightHex(x - 1, y);
        HighLightHex(x - 1, y + 1);
        HighLightHex(x, y - 1);
        HighLightHex(x, y + 1);
        HighLightHex(x + 1, y - 1);
        HighLightHex(x + 1, y);
    }

    private void HighLightHex(int x, int y)
    {
        Hex hex;
        if (grid.TryGetValue(new Key(x, y), out hex))
        {
            hex.SetHighlight();
        }
    }

    private void HighlightAllHexes()
    {
        foreach (var key in grid.Keys)
        {
            grid[key].SetHighlight();
        }
    }

    private bool CheckInBounds(int x, int y)
    {
        if (x >= -hexRadius && x <= hexRadius && y >= -hexRadius && y <= hexRadius)
        {
            return true;
        }
        return false;
    }
}
