using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {

    private bool selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (GameManager.instance.phase == Phase.SCOUT && mode == HexMode.HIGHLIGHT)
        {
            GameManager.instance.RevealHexes(x, y);
        }
    }
}
