using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ShopManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject workerCardFab = PrefabManager.instance.workerCardFab;

        GameObject obj1 = (GameObject)GameObject.Instantiate(workerCardFab, new Vector2(-5f, 0), Quaternion.identity);
        GameObject obj2 = (GameObject)GameObject.Instantiate(workerCardFab, Vector2.zero, Quaternion.identity);
        GameObject obj3 = (GameObject)GameObject.Instantiate(workerCardFab, new Vector2(5f, 0), Quaternion.identity);
        obj1.GetComponentInChildren<Text>().text = "Trikey";
        obj2.GetComponentInChildren<Text>().text = "Kalki";
        obj3.GetComponentInChildren<Text>().text = "Kiwi";

        GameObject obj4 = (GameObject)GameObject.Instantiate(PrefabManager.instance.worker5Fab, new Vector2(-5f, 0), Quaternion.identity);
        obj4.transform.localScale *= 2;
        GameObject obj5 = (GameObject)GameObject.Instantiate(PrefabManager.instance.worker9Fab, new Vector2(0, 0), Quaternion.identity);
        obj5.transform.localScale *= 2;
        GameObject obj6 = (GameObject)GameObject.Instantiate(PrefabManager.instance.worker8Fab, new Vector2(5f, 0), Quaternion.identity);
        obj6.transform.localScale *= 2;
    }

    public void GoToNextYear()
    {
        GlobalInfo.instance.AddWorker(WorkerType.WORKER9);
        SceneManager.LoadScene("Game");
    }
}
