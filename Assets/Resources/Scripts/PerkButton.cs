using UnityEngine;
using System.Collections;

public class PerkButton : MonoBehaviour {

    private Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponentInChildren<Canvas>();
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
}
