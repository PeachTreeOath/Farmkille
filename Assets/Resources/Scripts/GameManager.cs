using UnityEngine;
using UnityEngine.UI;
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

    [HideInInspector]
    public Phase phase = Phase.SCOUT;
    [HideInInspector]
    public Dictionary<Key, Hex> grid;

    private int year = 1;
    private List<Worker> workers;

    private Text yearText;
    private Text taxText;
    private Text goldText;
    private Text movesText;
    private TurnButton turnButton;

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

        LoadReferences();
    }

    private void LoadReferences()
    {
        GameObject canvas = GameObject.Find("Canvas");
        yearText = canvas.transform.Find("YearText").GetComponent<Text>();
        taxText = canvas.transform.Find("TaxText").GetComponent<Text>();
        goldText = canvas.transform.Find("GoldText").GetComponent<Text>();
        movesText = canvas.transform.Find("MoveText").GetComponent<Text>();
        turnButton = canvas.GetComponentInChildren<TurnButton>();
    }

    public void StartGame()
    {
        // Create main character


        GoToPhase(Phase.SCOUT);
    }

    /*
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
    */

    public void GoToPhase(Phase nextPhase)
    {
        // Revert phase first
        UnHighLightAllHexes();

        switch (nextPhase)
        {
            case Phase.SCOUT:
                FogAllHexes();
                RevealHexes(0, 0);
                break;
            case Phase.PLACEMENT:

                break;
            case Phase.ALIGNMENT:
                break;
            case Phase.GROW:
                break;
        }

        turnButton.GoToPhase(nextPhase);
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

    // Used in scout phase only
    private void HighlightAllHexes()
    {
        foreach (var key in grid.Keys)
        {
            grid[key].SetHighlight();
        }
    }

    private void UnHighLightAllHexes()
    {
        foreach (var key in grid.Keys)
        {
            if (grid[key].mode == HexMode.HIGHLIGHT)
            {
                grid[key].SetNormal();
            }
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
