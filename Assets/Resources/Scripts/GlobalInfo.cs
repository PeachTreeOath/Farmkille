using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalInfo : MonoBehaviour {

    public static GlobalInfo instance;

    public int year = 1;
    public int gold = 0;
    public int stamina = 5;
    public List<WorkerType> workers;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        InitWorkers();
    }

    public void AddWorker(WorkerType type)
    {
        workers.Add(type);
    }

    private void InitWorkers()
    {
        workers = new List<WorkerType>();
        workers.Add(WorkerType.WORKER1);
        workers.Add(WorkerType.WORKER2);
    }
}
