using UnityEngine;
using System.Collections;

public class WorkerFactory : MonoBehaviour {

    private GameObject mainCharFab;

    void Awake()
    {
        mainCharFab = Resources.Load<GameObject>("Prefabs/MainChar");
    }
	
    public Worker GetMainChar()
    {
        GameObject obj = Instantiate<GameObject>(mainCharFab);
        return obj.GetComponent<Worker>();
    }
}
