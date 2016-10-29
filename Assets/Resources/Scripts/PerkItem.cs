using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class PerkItem : MonoBehaviour {

    public SpriteRenderer sprite;

    // Use this for initialization
    void Start() {

    }
    
    void OnMouseDown()
    {
        sprite.enabled = !sprite.enabled;
    }
}
