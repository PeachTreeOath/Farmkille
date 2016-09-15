using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WorkerCard : MonoBehaviour {

    public WorkerType type;


    public void DisplayWorker(Worker worker, ShopManager mgr, int num)
    {
        type = worker.type;
        worker.transform.position = transform.Find("WorkerSlot").position;
        transform.Find("Name").GetComponent<Text>().text = worker.workerName;
        GetComponentInChildren<Button>().onClick.AddListener(delegate { mgr.GoToNextYear(num); });
    }
}
