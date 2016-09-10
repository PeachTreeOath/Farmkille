using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager instance;

    public Material normalMat;
    public Material fogMat;
    public Material highlightMat;
    public Material affectedMat;

    public GameObject bgFab;
    public GameObject hexFab;
    public GameObject hexTransparentFab;
    public GameObject tokenFab;

    public GameObject worker1Fab;
    public GameObject worker2Fab;

    public GameObject cropAppleFab;
    public GameObject cropBananaFab;
    public GameObject cropCherriesFab;
    public GameObject cropGrapesFab;

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

        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        normalMat = Resources.Load<Material>("Materials/Transparent");
        fogMat = Resources.Load<Material>("Materials/Fog");
        highlightMat = Resources.Load<Material>("Materials/Highlight");
        affectedMat = Resources.Load<Material>("Materials/Affected");

        bgFab = Resources.Load<GameObject>("Prefabs/BGTile");
        hexFab = Resources.Load<GameObject>("Prefabs/Hex");
        hexTransparentFab = Resources.Load<GameObject>("Prefabs/HexTransparent");
        tokenFab = Resources.Load<GameObject>("Prefabs/Token");

        worker1Fab = Resources.Load<GameObject>("Prefabs/Worker1");
        worker2Fab = Resources.Load<GameObject>("Prefabs/Worker2");

        cropAppleFab = Resources.Load<GameObject>("Prefabs/CropApple");
        cropBananaFab = Resources.Load<GameObject>("Prefabs/CropBanana");
        cropCherriesFab = Resources.Load<GameObject>("Prefabs/CropCherries");
        cropGrapesFab = Resources.Load<GameObject>("Prefabs/CropGrapes");
    }
}
