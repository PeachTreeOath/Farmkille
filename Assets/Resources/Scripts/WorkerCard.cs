using UnityEngine;
using System.Collections;

public class WorkerCard : MonoBehaviour {

    public WorkerType type;

    public void PlaceWorker(Transform worker)
    {
        worker.transform.position = transform.Find("WorkerSlot").position;
    }
}
