using UnityEngine;
using System.Collections;
using System;

public class WorkerFactory : MonoBehaviour
{
 
    public Worker GetMainChar()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        return obj.GetComponent<Worker>();
    }

}
