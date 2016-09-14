using UnityEngine;
using System.Collections;

public class GlobalInfo : MonoBehaviour {

    public static GlobalInfo instance;

    public int year;
    public int gold;

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

        DontDestroyOnLoad(gameObject);
    }

}
