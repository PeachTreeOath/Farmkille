using UnityEngine;
using System.Collections;

public class WorkerFactory : MonoBehaviour
{

    private GameObject mainCharFab;

    void Awake()
    {
        mainCharFab = Resources.Load<GameObject>("Prefabs/MainChar");
    }

    public Worker GetMainChar()
    {
        GameObject obj = Instantiate<GameObject>(mainCharFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        return obj.GetComponent<Worker>();
    }

    public WorkerIcon GetMainCharIcon()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerIconFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        return obj.GetComponent<WorkerIcon>();
    }
}
