using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    private ScreenFader screenFader;

    // Use this for initialization
    void Start () {
        screenFader = GameObject.Find("Canvas/ScreenFader").GetComponent<ScreenFader>();
        screenFader.FadeIn();
    }
	
    public void GoToGame()
    {
        screenFader.FadeOut("Game");
    }

    public void GoToBuildings()
    {
        SceneManager.LoadScene("Buildings");
    }
}
