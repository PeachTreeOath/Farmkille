using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

public class WorkerIcon : MonoBehaviour, IPointerClickHandler
{

    private bool selected;

    private void SelectWorker(bool enabled)
    {
        selected = enabled;
       // GameManager.instance.PlaceUnitOnCursor(this);
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
