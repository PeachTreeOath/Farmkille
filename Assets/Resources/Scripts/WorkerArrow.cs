using UnityEngine;
using System.Collections;

public class WorkerArrow : MonoBehaviour {

    public bool isFacingLeft;

    public void FaceLeft()
    {
        isFacingLeft = true;
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
