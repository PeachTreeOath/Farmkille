using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalInfo : Singleton<GlobalInfo>
{

    public static GlobalInfo instance;

    public int year = 1;
    public int gold = 0;
    public int exp = 0;
    public int stamina = 5;

    public List<WorkerType> workers;

    protected override void Awake()
    {
        base.Awake();
        base.SetScenePersistence();

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
