using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour {

    public static PrefabManager instance;

    public GameObject highlightFab;
    public GameObject bgFab;
    public GameObject hexFab;

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
        highlightFab = Resources.Load<GameObject>("Materials/Highlight");

        bgFab = Resources.Load<GameObject>("Prefabs/BGTile");
        hexFab = Resources.Load<GameObject>("Prefabs/Hex");
    }

}
