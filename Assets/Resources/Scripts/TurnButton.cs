using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnButton : MonoBehaviour
{

    private Button button;
    private Text buttonText;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "End Turn";
    }

    public void GoToPhase(Phase newPhase)
    {
        switch (newPhase)
        {
            case Phase.SCOUT:
                button.enabled = false;
                break;
            case Phase.PLACEMENT:
                button.enabled = true;
                break;
            case Phase.ALIGNMENT:
                button.enabled = false;
                break;
            case Phase.GROW:
                button.enabled = false;
                break;
            case Phase.RESULTS:

                break;
        }
    }

    public void EndTurn()
    {
        GameManager.instance.GoToPhase(Phase.GROW);
    }
}
