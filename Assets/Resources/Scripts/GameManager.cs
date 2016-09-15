using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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

    private int stamina;
    private int tax = 5;
    private int gold;

    private int year = 1;
    private List<Hex> cropHexes;
    private List<Worker> workers;
    private WorkerFactory workerFactory;
    public WorkerMenu workerMenu;

    public Worker selectedUnit;
    public Hex currentHoveredHex;

    public GameObject canvas;
    private Text yearText;
    private Text taxText;
    private Text goldText;
    private Text movesText;

    private GameObject resourceParent;
    private GameObject workerParent;

    private List<Crop> growingCrops;
    private float elapsedGrowTime;
    public float growSpeed;

    private TurnButton turnButton;
    private ScreenFader screenFader;
    private CanvasGroup resultsCanvas;
    private Text resultsText;

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
        year = GlobalInfo.instance.year;
        gold = GlobalInfo.instance.gold;
        stamina = GlobalInfo.instance.stamina;

        workers = new List<Worker>();
        cropHexes = new List<Hex>();
        canvas = GameObject.Find("Canvas");
        yearText = canvas.transform.Find("YearText").GetComponent<Text>();
        taxText = canvas.transform.Find("TaxText").GetComponent<Text>();
        goldText = canvas.transform.Find("GoldText").GetComponent<Text>();
        movesText = canvas.transform.Find("MovesText").GetComponent<Text>();
        resourceParent = GameObject.Find("Resources");
        workerParent = GameObject.Find("Workers");
        screenFader = canvas.GetComponentInChildren<ScreenFader>();
        turnButton = canvas.GetComponentInChildren<TurnButton>();
        resultsCanvas = canvas.GetComponentInChildren<CanvasGroup>();
        resultsText = resultsCanvas.transform.Find("ResultsGold").GetComponent<Text>();
        growingCrops = new List<Crop>();
        workerMenu = canvas.GetComponentInChildren<WorkerMenu>();
        workerFactory = WorkerFactory.instance;
        workerFactory.Init();
    }

    public void StartGame()
    {
        // Set up UI
        yearText.text = "YEAR " + year;
        taxText.text = "Tax: " + tax;
        goldText.text = "Gold: " + gold;

        // Create starting workers
        foreach(WorkerType type in GlobalInfo.instance.workers)
        {
            workers.Add(workerFactory.CreateWorker(type));
        }

        PopulateWorkerMenu();
        GoToPhase(Phase.SCOUT);
        GoToPhase(Phase.PLACEMENT);
    }

    void Update()
    {
        switch (phase)
        {
            //case Phase.SCOUT:

            //    break;
            //case Phase.PLACEMENT:

            //    break;
            //case Phase.ALIGNMENT:

            //    break;
            case Phase.GROW:
                elapsedGrowTime += growSpeed * Time.deltaTime;
                float scale = Mathf.Lerp(1, 2, elapsedGrowTime);
                Vector2 newScale = new Vector2(scale, scale);
                foreach (Crop crop in growingCrops)
                {
                    crop.transform.localScale = newScale;
                }
                if (elapsedGrowTime >= 2)
                {
                    GoToPhase(Phase.RESULTS);
                }
                break;
        }
    }

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
                //TODO: Bring back fog of war
                //SetAllHexes(HexMode.FOG);
                RevealHexes(0, 0);
                screenFader.FadeIn();
                break;
            case Phase.PLACEMENT:

                break;
            case Phase.ALIGNMENT:
                break;
            case Phase.GROW:
                StartGrowing();
                break;
            case Phase.RESULTS:
                ShowResultsPanel(true);
                break;
            case Phase.FADEOUT:
                ShowResultsPanel(false);
                screenFader.FadeOut();
                break;
        }

        turnButton.GoToPhase(nextPhase);
        phase = nextPhase;
    }

    private void StartGrowing()
    {
        // Find crops whose requirements are all met
        foreach (Hex hex in cropHexes)
        {
            Crop crop = hex.crop;
            if (crop.AreAllResourcesMet())
            {
                crop.SetTokenLayer(TokenDisplayer.TokenLayer.Invisible);
                growingCrops.Add(crop);
            }
        }
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

    private void SetAllNonCropHexes(HexMode mode)
    {
        foreach (var key in grid.Keys)
        {
            Hex hex = grid[key];
            if (hex.crop == null)
            {
                hex.SetHexMode(mode);
            }
        }
    }

    private void RemoveAllHexes(HexMode mode)
    {
        foreach (var key in grid.Keys)
        {
            grid[key].RemoveHexMode(mode);
        }
    }

    public void ShowAffectedHexes()
    {
        if (selectedUnit == null)
        {
            return;
        }

        ITileAffector affector = selectedUnit.GetComponent<ITileAffector>();
        if (affector == null)
        {
            return;
        }

        RemoveAllHexes(HexMode.AFFECTED);
        List<Key> affectedTiles = affector.GetAffectedTiles(currentHoveredHex);

        foreach (Key hexPosition in affectedTiles)
        {
            Key key = new Key(hexPosition.x, hexPosition.y);
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

    private void PopulateWorkerMenu()
    {
        workerMenu.PopulateWorkerMenu(workers);
    }

    public void PlaceUnitOnCursor(Worker worker)
    {
        selectedUnit = worker;
        SetAllNonCropHexes(HexMode.HIGHLIGHT);
        CheckCropNeeds();
    }

    public void PlaceUnitInHex(Hex hex)
    {
        if (hex.mode != HexMode.HIGHLIGHT)
        {
            return;
        }
        selectedUnit.transform.SetParent(workerParent.transform);
        selectedUnit.SetHex(hex);
        selectedUnit = null;
        RemoveAllHexes(HexMode.HIGHLIGHT);
        RemoveAllHexes(HexMode.AFFECTED);
        CheckCropNeeds();
    }

    public void RegisterCropHex(Hex hex)
    {
        cropHexes.Add(hex);
    }

    public void CheckCropNeeds()
    {
        // Clear all needs first
        foreach (Hex cropHex in cropHexes)
        {
            cropHex.crop.ResetNeeds();
        }

        // Go through all workers and add resources to crop
        foreach (Worker worker in workers)
        {
            // Don't bother if not deployed
            if (worker.hex == null)
            {
                continue;
            }

            // Some workers might not affect tiles
            ITileAffector affector = worker.GetComponent<ITileAffector>();
            if (affector == null)
            {
                continue;
            }

            List<Key> affectedTiles = affector.GetAffectedTiles(worker.hex);

            foreach (Key hexPosition in affectedTiles)
            {
                Key key = new Key(hexPosition.x, hexPosition.y);
                Hex hex;
                if (grid.TryGetValue(key, out hex))
                {
                    Crop crop = hex.crop;

                    // If crop exists in hex, apply resources
                    if (crop != null)
                    {
                        crop.ApplyResources(worker.GetComponent<ResourceProducer>().GetProductionMap());
                    }
                }
            }
        }
    }

    private void ShowResultsPanel(bool enablePanel)
    {
        foreach(Crop crop in growingCrops)
        {
            gold += crop.goldValue;
        }
        int goldEarned = gold - tax;

        if (enablePanel)
        {
            canvas.GetComponent<Canvas>().sortingLayerName = "ScreenFader";
            resultsCanvas.alpha = 1;
            resultsCanvas.interactable = true;
            resultsCanvas.blocksRaycasts = true;

            resultsText.text = "Gold: " + gold + "\nTax: -" + tax + "\n\nGold Earned: " + goldEarned;
        }
        else
        {
            resultsCanvas.alpha = 0;
            resultsCanvas.interactable = false;
            resultsCanvas.blocksRaycasts = false;
        }

        gold = goldEarned;
    }

    // Used for harvest button
    public void GoToFadeoutPhase()
    {
        GoToPhase(Phase.FADEOUT);
    }

    public void GoToShop()
    {
        SaveStatsToGlobal();
        SceneManager.LoadScene("Shop");
    }

    public void GoToNextYear()
    {
        SaveStatsToGlobal();
        SceneManager.LoadScene("Game");
    }

    private void SaveStatsToGlobal()
    {
        GlobalInfo.instance.year = year + 1;
        GlobalInfo.instance.gold = gold;
    }
}
