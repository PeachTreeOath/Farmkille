using UnityEngine;
using System.Collections;

public class Hex : MonoBehaviour
{

    public int row;
    public int col;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void EnableFog()
    {
        spriteRenderer.material = PrefabManager.instance.fogMat;
    }

    public void EnableHighlight()
    {
        spriteRenderer.material = PrefabManager.instance.highlightMat;
    }

}
