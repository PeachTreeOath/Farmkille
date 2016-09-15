using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Worker : MonoBehaviour
{

    public string workerName;
    public Hex hex;

    private bool selected;
    private BoxCollider2D col;
    private ResourceProducer producer; // Producer can be null if it doesn't actually produce resources (ie. friendly buffer)
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        producer = GetComponent<ResourceProducer>();
        if (producer != null)
        {
            producer.SetTokenLayer(TokenDisplayer.TokenLayer.UI);
        }
    }

    public void SelectWorker(bool enabled)
    {
        selected = enabled;
        col.enabled = !enabled; // Turn off collider so raycasts don't hit it
        GameManager.instance.PlaceUnitOnCursor(this);
        producer.SetTokenLayer(TokenDisplayer.TokenLayer.UI);
    }

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
        spriteRenderer.sortingLayerName = "Worker";
        if (producer != null)
        {
            producer.SetTokenLayer(TokenDisplayer.TokenLayer.Invisible);
        }
    }

    // Removes hex reference from worker, but only removes worker reference from
    // hex if removeRefFromHex is true so that swapping can properly occur 
    public void UnsetHex(Boolean removeRefFromHex)
    {
        if (removeRefFromHex)
        {
            hex.worker = null;
        }
        hex = null;
        SelectWorker(true);
    }

    // Used by worker menu when worker is slid into the board via Next Page
    public void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            spriteRenderer.sortingLayerName = "MenuWorker";
            producer.SetTokenLayer(TokenDisplayer.TokenLayer.UI);
            col.enabled = true;
        }
        else
        {
            spriteRenderer.sortingLayerName = "Invisible";
            producer.SetTokenLayer(TokenDisplayer.TokenLayer.Invisible);
            col.enabled = false;
        }
    }
}
