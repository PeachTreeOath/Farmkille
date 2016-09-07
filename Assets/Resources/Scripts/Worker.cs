using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Worker : MonoBehaviour
{

    public Hex hex;

    private bool selected;
    private BoxCollider2D col;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void SelectWorker(bool enabled)
    {
        selected = enabled;
        col.enabled = !enabled; // Turn off collider so raycasts don't hit it
        GameManager.instance.PlaceUnitOnCursor(this);
    }

    //public void OnPointerClick(PointerEventData eventData)
    void OnMouseDown()
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

    public void SetHex(Hex newHex)
    {
        newHex.worker = this;
        hex = newHex;
        transform.position = newHex.transform.position;
    }

    public void UnsetHex()
    {
        hex.worker = null;
        hex = null;
        SelectWorker(true);
    }

}
