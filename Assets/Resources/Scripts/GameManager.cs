using UnityEngine;
using UnityEngine.EventSystems;
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
    private List<WorkerIcon> workerIcons;
    private WorkerFactory workerFactory;
    private GameObject selectedUnit;
    private SpriteRenderer selectedUnitImage;

    public GameObject canvas;
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
        workerIcons = new List<WorkerIcon>();
        workerFactory = gameObject.AddComponent<WorkerFactory>();
        selectedUnitImage = transform.Find("SelectedUnitImage").GetComponent<SpriteRenderer>();
        selectedUnitImage.enabled = false;

        canvas = GameObject.Find("Canvas");
        yearText = canvas.transform.Find("YearText").GetComponent<Text>();
        taxText = canvas.transform.Find("TaxText").GetComponent<Text>();
        goldText = canvas.transform.Find("GoldText").GetComponent<Text>();
        movesText = canvas.transform.Find("MovesText").GetComponent<Text>();
        turnButton = canvas.GetComponentInChildren<TurnButton>();
    }

    public void StartGame()
    {
        // Create main character
        workerIcons.Add(workerFactory.GetMainCharIcon());

        // Create worker menu in panel and hide
        CreateWorkerMenu();

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

    void LateUpdate()
    {
        if (selectedUnit != null)
        {
            Vector2 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedUnitImage.transform.position = mouseVector;
        }
    }

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

    private void CreateWorkerMenu()
    {
        // Workers are divided into a 5x2 menu
        int startCol1X = 585;
        int startCol2X = 720;
        int startY = 195;
        int diffY = 110;

        //TODO: Add paging if workers > 10
        for (int i = 0; i < workerIcons.Count; i++)
        {
            int x = workerIcons.Count < 5 ? startCol1X : startCol2X;
            int y = startY - i % 5 * diffY;

            workerIcons[i].transform.localPosition = new Vector2(x, y);
        }
    }

    public void PlaceUnitOnCursor(WorkerIcon workerIcon)
    {
        selectedUnit = workerIcon.gameObject;
        selectedUnitImage.sprite = PrefabManager.instance.workerIconFab.GetComponent<SpriteRenderer>().sprite;
        selectedUnitImage.enabled = true;
    }

}
