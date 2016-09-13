using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnButton : MonoBehaviour
{

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void GoToPhase(Phase newPhase)
    {
        switch (newPhase)
        {
            case Phase.SCOUT:
                button.interactable = false;
                break;
            case Phase.PLACEMENT:
                button.interactable = true;
                break;
            case Phase.ALIGNMENT:
                button.interactable = false;
                break;
            case Phase.GROW:
                button.interactable = false;
                break;
            case Phase.RESULTS:
                button.interactable = false;
                break;
        }
    }

    public void EndTurn()
    {
        GameManager.instance.GoToPhase(Phase.GROW);
    }
}
