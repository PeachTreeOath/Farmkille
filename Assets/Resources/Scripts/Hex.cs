using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour
{

    public HexMode mode;

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
        if (GameManager.instance.phase == Phase.SCOUT && mode == HexMode.HIGHLIGHT)
        {
            GameManager.instance.RevealHexes(x, y, z);
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
