using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour
{

    private bool selected;
    private SpriteRenderer border;

    void Awake()
    {
        border = transform.FindChild("Border").GetComponent<SpriteRenderer>();
        border.enabled = false;
    }

    void OnMouseDown()
    {
        if (GameManager.instance.phase == Phase.PLACEMENT)
        {
            if (selected == false)
            {
                SelectWorker(enabled);
            }
            else
            {
                SelectWorker(enabled);
            }
        }
    }

    private void SelectWorker(bool enabled)
    {
        selected = enabled;
        border.enabled = enabled;
    }
}
