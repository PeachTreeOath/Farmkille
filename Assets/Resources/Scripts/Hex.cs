using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Hex : MonoBehaviour
{

    public HexMode mode;
    public Worker worker;

    public int x;
    public int y;
    public int z;

    private SpriteRenderer spriteRenderer;
    private HashSet<Material> matSet;
    private Material normalMat;
    private Material fogMat;
    private Material highlightMat;
    private Material affectedMat;
    private Dictionary<HexMode, Material> matMap;

    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        matSet = new HashSet<Material>();
        matMap = new Dictionary<HexMode, Material>();
        normalMat = PrefabManager.instance.normalMat;
        fogMat = PrefabManager.instance.fogMat;
        highlightMat = PrefabManager.instance.highlightMat;
        affectedMat = PrefabManager.instance.affectedMat;
        matMap.Add(HexMode.NORMAL, normalMat);
        matMap.Add(HexMode.FOG, fogMat);
        matMap.Add(HexMode.HIGHLIGHT, highlightMat);
        matMap.Add(HexMode.AFFECTED, affectedMat);

        SetHexMode(HexMode.NORMAL);
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        switch (GameManager.instance.phase)
        {
            case Phase.SCOUT:
                if (mode == HexMode.HIGHLIGHT)
                {
                    GameManager.instance.RevealHexes(x, y);
                }
                break;
            case Phase.PLACEMENT:
                // Place unit into blank hex
                if (mode == HexMode.HIGHLIGHT && worker == null)
                {
                    GameManager.instance.PlaceUnitInHex(this);
                }
                else if (worker != null)
                {
                    // Pick up unit
                    if (GameManager.instance.selectedUnit == null)
                    {
                        worker.UnsetHex(false);
                    }
                    // Swap unit with currently selected one
                    else
                    {
                        Worker tempWorker = worker;
                        GameManager.instance.PlaceUnitInHex(this);
                        tempWorker.UnsetHex(true);
                    }
                }
                break;
            case Phase.ALIGNMENT:
                break;
            case Phase.GROW:
                break;
        }

    }

    void OnMouseEnter()
    {
        Worker worker = GameManager.instance.selectedUnit;
        if (worker != null)
        {
            //TODO: Check phase first
            List<GameManager.Key> affectedTiles = worker.GetComponent<ITileAffector>().GetAffectedTiles();
            GameManager.instance.ShowAffectedHexes(this, affectedTiles);
        }
    }

    public void SetCoords(int q, int r, int s)
    {
        x = q;
        y = r;
        z = s;
    }

    public void SetCoords(int q, int r)
    {
        x = q;
        y = r;
        z = -q - r;
    }

    public void SetHexMode(HexMode mode)
    {
        matSet.Add(matMap[mode]);
        SetHighestHexMode();
    }

    public void RemoveHexMode(HexMode mode)
    {
        matSet.Remove(matMap[mode]);
        SetHighestHexMode();
    }

    private void SetHighestHexMode()
    {
        if (matSet.Contains(fogMat))
        {
            mode = HexMode.FOG;
            spriteRenderer.material = fogMat;
        }
        else if (matSet.Contains(affectedMat))
        {
            mode = HexMode.AFFECTED;
            spriteRenderer.material = affectedMat;
        }
        else if (matSet.Contains(highlightMat))
        {
            mode = HexMode.HIGHLIGHT;
            spriteRenderer.material = highlightMat;
        }
        else if (matSet.Contains(normalMat))
        {
            mode = HexMode.NORMAL;
            spriteRenderer.material = normalMat;
        }

    }
}
