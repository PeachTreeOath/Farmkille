using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PerkButton : MonoBehaviour {

    public SpriteRenderer sprite;
    private Canvas canvas;
    private SpriteRenderer highlight;

	// Use this for initialization
	void Start () {
        canvas = GetComponentInChildren<Canvas>();
        highlight = transform.Find("perkHighlight").GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        canvas.enabled = true;
    }

    void OnMouseExit()
    {
        canvas.enabled = false;
    }

    void OnMouseDown()
    {
        sprite.enabled = !sprite.enabled;
        highlight.enabled = !highlight.enabled;
    }

}
