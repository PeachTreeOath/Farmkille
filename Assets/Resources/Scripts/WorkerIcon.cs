using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkerIcon : MonoBehaviour
{

    private bool selected;
    private Image border;

    void Awake()
    {
        Image[] images = transform.FindChild("Border").GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.gameObject.GetInstanceID() != gameObject.GetInstanceID())
            {
                border = image;
                break;
            }
        }
        border.enabled = false;
    }

    void OnMouseDown()
    {
        if (GameManager.instance.phase == Phase.PLACEMENT)
        {
            if (selected == false)
            {
                SelectWorker(true);
            }
            else
            {
                SelectWorker(false);
            }
        }
    }

    private void SelectWorker(bool enabled)
    {
        selected = enabled;
        border.enabled = enabled;
    }
}
