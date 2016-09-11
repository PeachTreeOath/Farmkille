using UnityEngine;
using System.Collections;

public class WorkerArrow : MonoBehaviour
{

    public bool isEnabled = true;
    public bool isFacingLeft;
    [HideInInspector]
    public WorkerMenu menu;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceLeft()
    {
        isFacingLeft = true;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    void OnMouseDown()
    {
        if (!isEnabled)
        {
            return;
        }

        if (isFacingLeft)
        {
            menu.PrevPage();
        }
        else
        {
            menu.NextPage();
        }
    }

    public void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
        if (enabled)
        {
            spriteRenderer.material = PrefabManager.instance.normalMat;
        }
        else
        {
            spriteRenderer.material = PrefabManager.instance.grayMat;
        }
    }
}
