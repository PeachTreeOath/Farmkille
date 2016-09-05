using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour {

    public static PrefabManager instance;

    public Material fogMat;
    public Material highlightMat;

    public GameObject bgFab;
    public GameObject hexFab;
    public GameObject hexTransparentFab;
    public GameObject workerIconFab;

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

        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        fogMat = Resources.Load<Material>("Materials/Fog");
        highlightMat = Resources.Load<Material>("Materials/Highlight");

        bgFab = Resources.Load<GameObject>("Prefabs/BGTile");
        hexFab = Resources.Load<GameObject>("Prefabs/Hex");
        hexTransparentFab = Resources.Load<GameObject>("Prefabs/HexTransparent");
        workerIconFab = Resources.Load<GameObject>("Prefabs/WorkerIcon");
    }

}
