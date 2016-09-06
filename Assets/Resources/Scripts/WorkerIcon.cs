using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

public class WorkerIcon : MonoBehaviour, IPointerClickHandler
{

    private bool selected;
    private Image border;

    void Awake()
    {

    }

    private void SelectWorker(bool enabled)
    {
        selected = enabled;
        border.enabled = enabled;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO: Reinstate
        //if (GameManager.instance.phase == Phase.PLACEMENT)
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
}
