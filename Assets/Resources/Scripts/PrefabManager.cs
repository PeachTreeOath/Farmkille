using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour {

    public static PrefabManager instance;

    public Material fogMat;
    public Material highlightMat;
    public Material affectedMat;

    public GameObject bgFab;
    public GameObject hexFab;
    public GameObject hexTransparentFab;
    public GameObject workerFab;

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
        affectedMat = Resources.Load<Material>("Materials/Affected");

        bgFab = Resources.Load<GameObject>("Prefabs/BGTile");
        hexFab = Resources.Load<GameObject>("Prefabs/Hex");
        hexTransparentFab = Resources.Load<GameObject>("Prefabs/HexTransparent");
        workerFab = Resources.Load<GameObject>("Prefabs/Worker");
    }

}
