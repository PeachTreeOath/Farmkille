using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Hex : MonoBehaviour
{

    public HexMode mode;
    public Worker worker;

    public int x;
    public int y;
    public int z;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
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

    private void ShowSprite(bool enable)
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.enabled = enable;
    }

    public void SetNormal()
    {
        ShowSprite(false);
        mode = HexMode.NORMAL;
    }

    public void SetFog()
    {
        ShowSprite(true);
        spriteRenderer.material = PrefabManager.instance.fogMat;
        mode = HexMode.FOG;
    }

    public void SetHighlight()
    {
        ShowSprite(true);
        spriteRenderer.material = PrefabManager.instance.highlightMat;
        mode = HexMode.HIGHLIGHT;
    }

}
