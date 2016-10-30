using UnityEngine;
using System.Collections;

/// <summary>
/// Unity singleton implementation. Call SetScenePersistence() to persist objects between scenes.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    public static T instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScenePersistence()
    {
        DontDestroyOnLoad(gameObject);
    }
}
