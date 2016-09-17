using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuildingsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
