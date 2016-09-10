using UnityEngine;
using System.Collections;
using System;

public class WorkerFactory : MonoBehaviour
{
 
    public Worker CreateWorker1()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.worker1Fab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        return obj.GetComponent<Worker>();
    }

    public Worker CreateWorker2()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.worker2Fab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        return obj.GetComponent<Worker>();
    }

    public WorkerArrow CreateWorkerLeftArrow()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerArrowFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        WorkerArrow arrow = obj.GetComponent<WorkerArrow>();
        arrow.FaceLeft();
        return arrow;
    }

    public WorkerArrow CreateWorkerRightArrow()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerArrowFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        WorkerArrow arrow = obj.GetComponent<WorkerArrow>();
        return arrow;
    }
}
