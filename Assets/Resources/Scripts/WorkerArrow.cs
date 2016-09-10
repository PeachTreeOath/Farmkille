using UnityEngine;
using System.Collections;

public class WorkerArrow : MonoBehaviour
{

    public bool isFacingLeft;
    [HideInInspector]
    public WorkerMenu menu;

    public void FaceLeft()
    {
        isFacingLeft = true;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
    //TODOOOOOOOOOOO Set menu!!!
    void OnMouseDown()
    {
        if (isFacingLeft)
        {
            menu.PrevPage();
        }
        else
        {
            menu.NextPage();
        }
    }
}
