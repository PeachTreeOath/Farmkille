using UnityEngine;
using System.Collections;
using System;

public class WorkerFactory : MonoBehaviour
{

    private Transform parent;

    public void Init()
    {
        parent = GameManager.instance.workerMenu.transform;
    }

    public Worker CreateWorker1()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.worker1Fab);
        obj.transform.SetParent(parent);
        return obj.GetComponent<Worker>();
    }

    public Worker CreateWorker2()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.worker2Fab);
        obj.transform.SetParent(parent);
        return obj.GetComponent<Worker>();
    }

}
