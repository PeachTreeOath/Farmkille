using UnityEngine;
using System.Collections;
using System;

public class WorkerFactory : MonoBehaviour
{

    public static WorkerFactory instance;

    private Transform parent;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Init()
    {
        if (GameManager.instance != null)
        {
            parent = GameManager.instance.workerMenu.transform;
        }
    }

    public Worker CreateWorker(WorkerType type)
    {
        switch (type)
        {
            case WorkerType.WORKER1:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker1Fab);
            case WorkerType.WORKER2:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker2Fab);
            case WorkerType.WORKER3:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker3Fab);
            case WorkerType.WORKER4:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker4Fab);
            case WorkerType.WORKER5:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker5Fab);
            case WorkerType.WORKER6:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker6Fab);
            case WorkerType.WORKER7:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker7Fab);
            case WorkerType.WORKER8:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker8Fab);
            case WorkerType.WORKER9:
                return CreateWorkerFromPrefab(PrefabManager.instance.worker9Fab);
        }

        return null;
    }

    public Worker CreateRandomWorker()
    {
        int typeNum = UnityEngine.Random.Range(0, Enum.GetNames(typeof(WorkerType)).Length);
        WorkerType type = (WorkerType)typeNum;

        return CreateWorker(type);
    }

    private Worker CreateWorkerFromPrefab(GameObject prefab)
    {
        GameObject obj = Instantiate<GameObject>(prefab);
        obj.transform.SetParent(parent);
        return obj.GetComponent<Worker>();
    }

}
