using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

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
    private int moves = 2;
    private List<Worker> workers;
    private WorkerFactory workerFactory;
    public Worker selectedUnit;

    public GameObject canvas;
    private Text yearText;
    private Text taxText;
    private Text goldText;
    private Text movesText;
    private GameObject resourceParent;
    private GameObject workerParent;

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
        workers = new List<Worker>();
        workerFactory = gameObject.AddComponent<WorkerFactory>();

        canvas = GameObject.Find("Canvas");
        yearText = canvas.transform.Find("YearText").GetComponent<Text>();
        taxText = canvas.transform.Find("TaxText").GetComponent<Text>();
        goldText = canvas.transform.Find("GoldText").GetComponent<Text>();
        movesText = canvas.transform.Find("MovesText").GetComponent<Text>();
        turnButton = canvas.GetComponentInChildren<TurnButton>();
        resourceParent = GameObject.Find("Resources");
        workerParent = GameObject.Find("Workers");
    }

    public void StartGame()
    {
        // Set up UI
        yearText.text = "YEAR " + year;
        taxText.text = "Tax: " + 25;
        goldText.text = "Gold: " + 0;

        // Create main character
        workers.Add(workerFactory.GetMainChar());
        workers.Add(workerFactory.GetMainChar());

        // Create worker menu in panel and hide
        CreateWorkerMenu();

        GoToPhase(Phase.SCOUT);
        GoToPhase(Phase.PLACEMENT);
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

    void LateUpdate()
    {
        canvas.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

        if (selectedUnit != null)
        {
            Vector2 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedUnit.transform.position = mouseVector;
        }
    }

    public void GoToPhase(Phase nextPhase)
    {
        // Revert phase first
        RemoveAllHexes(HexMode.AFFECTED);
        RemoveAllHexes(HexMode.HIGHLIGHT);

        switch (nextPhase)
        {
            case Phase.SCOUT:
                SetAllHexes(HexMode.FOG);
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
        phase = nextPhase;
    }

    public void RevealHexes(int x, int y)
    {
        RemoveHex(x, y, HexMode.FOG);
        RemoveHex(x - 1, y, HexMode.FOG);
        RemoveHex(x - 1, y + 1, HexMode.FOG);
        RemoveHex(x, y - 1, HexMode.FOG);
        RemoveHex(x, y + 1, HexMode.FOG);
        RemoveHex(x + 1, y - 1, HexMode.FOG);
        RemoveHex(x + 1, y, HexMode.FOG);
    }

    private void SetHex(int x, int y, HexMode mode)
    {
        Hex hex;
        if (grid.TryGetValue(new Key(x, y), out hex))
        {
            hex.SetHexMode(mode);
        }
    }

    private void RemoveHex(int x, int y, HexMode mode)
    {
        Hex hex;
        if (grid.TryGetValue(new Key(x, y), out hex))
        {
            hex.RemoveHexMode(mode);
        }
    }

    private void SetAllHexes(HexMode mode)
    {
        foreach (var key in grid.Keys)
        {
            grid[key].SetHexMode(mode);
        }
    }

    private void RemoveAllHexes(HexMode mode)
    {
        foreach (var key in grid.Keys)
        {
            grid[key].RemoveHexMode(mode);
        }
    }

    public void ShowAffectedHexes(Hex centerHex, List<GameManager.Key> hexes)
    {
        RemoveAllHexes(HexMode.AFFECTED);
        foreach (GameManager.Key hexPosition in hexes)
        {
            Key key = new Key(hexPosition.x + centerHex.x, hexPosition.y + centerHex.y);
            Hex hex;
            if (grid.TryGetValue(key, out hex))
            {
                hex.SetHexMode(HexMode.AFFECTED);
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

    private void CreateWorkerMenu()
    {
        // Workers are divided into a 5x2 menu
        int startCol1X = 585;
        int startCol2X = 720;
        int startY = 195;
        int diffY = 110;

        //TODO: Add paging if workers > 10
        for (int i = 0; i < workers.Count; i++)
        {
            int x = workers.Count < 5 ? startCol1X : startCol2X;
            int y = startY - i % 5 * diffY;

            workers[i].transform.localPosition = new Vector2(x, y);
        }
    }

    public void PlaceUnitOnCursor(Worker worker)
    {
        selectedUnit = worker;
        SetAllHexes(HexMode.HIGHLIGHT);
    }

    public void PlaceUnitInHex(Hex hex)
    {
        selectedUnit.transform.SetParent(workerParent.transform);
        selectedUnit.SetHex(hex);
        selectedUnit = null;
        RemoveAllHexes(HexMode.HIGHLIGHT);
        RemoveAllHexes(HexMode.AFFECTED);
        //TODO: Add watering calculations each time you place
    }
}
