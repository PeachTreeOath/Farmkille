using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager instance;

    public Material normalMat;
    public Material grayMat;
    public Material transparentMat;
    public Material fogMat;
    public Material highlightMat;
    public Material affectedMat;

    public GameObject bgFab;
    public GameObject hexFab;
    public GameObject hexTransparentFab;
    public GameObject tokenFab;
    public GameObject workerArrowFab;

    public GameObject worker1Fab;
    public GameObject worker2Fab;
    public GameObject worker3Fab;
    public GameObject worker4Fab;
    public GameObject worker5Fab;
    public GameObject worker6Fab;
    public GameObject worker7Fab;
    public GameObject worker8Fab;
    public GameObject worker9Fab;
    
    public GameObject cropAppleFab;
    public GameObject cropBananaFab;
    public GameObject cropCherriesFab;
    public GameObject cropGrapesFab;

    public GameObject workerCardFab;

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
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        normalMat = Resources.Load<Material>("Materials/Normal");
        grayMat = Resources.Load<Material>("Materials/Gray");
        transparentMat = Resources.Load<Material>("Materials/Transparent");
        fogMat = Resources.Load<Material>("Materials/Fog");
        highlightMat = Resources.Load<Material>("Materials/Highlight");
        affectedMat = Resources.Load<Material>("Materials/Affected");

        bgFab = Resources.Load<GameObject>("Prefabs/BGTile");
        hexFab = Resources.Load<GameObject>("Prefabs/Hex");
        hexTransparentFab = Resources.Load<GameObject>("Prefabs/HexTransparent");
        tokenFab = Resources.Load<GameObject>("Prefabs/Token");
        workerArrowFab = Resources.Load<GameObject>("Prefabs/WorkerArrow");

        worker1Fab = Resources.Load<GameObject>("Prefabs/Worker1");
        worker2Fab = Resources.Load<GameObject>("Prefabs/Worker2");
        worker3Fab = Resources.Load<GameObject>("Prefabs/Worker3");
        worker4Fab = Resources.Load<GameObject>("Prefabs/Worker4");
        worker5Fab = Resources.Load<GameObject>("Prefabs/Worker5");
        worker6Fab = Resources.Load<GameObject>("Prefabs/Worker6");
        worker7Fab = Resources.Load<GameObject>("Prefabs/Worker7");
        worker8Fab = Resources.Load<GameObject>("Prefabs/Worker8");
        worker9Fab = Resources.Load<GameObject>("Prefabs/Worker9");
        
        cropAppleFab = Resources.Load<GameObject>("Prefabs/CropApple");
        cropBananaFab = Resources.Load<GameObject>("Prefabs/CropBanana");
        cropCherriesFab = Resources.Load<GameObject>("Prefabs/CropCherries");
        cropGrapesFab = Resources.Load<GameObject>("Prefabs/CropGrapes");

        workerCardFab = Resources.Load<GameObject>("Prefabs/WorkerCard");
    }
}
