using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{

    WorkerCard card1;
    WorkerCard card2;
    WorkerCard card3;
    // Use this for initialization
    void Start()
    {
        GameObject workerCardFab = PrefabManager.instance.workerCardFab;

        card1 = ((GameObject)GameObject.Instantiate(workerCardFab, new Vector2(-5f, 0), Quaternion.identity)).GetComponent<WorkerCard>();
        card2 = ((GameObject)GameObject.Instantiate(workerCardFab, Vector2.zero, Quaternion.identity)).GetComponent<WorkerCard>();
        card3 = ((GameObject)GameObject.Instantiate(workerCardFab, new Vector2(5f, 0), Quaternion.identity)).GetComponent<WorkerCard>();

        List<WorkerType> rolledTypes = new List<WorkerType>();
        Worker worker1 = CreateRandomWorker(rolledTypes);
        rolledTypes.Add(worker1.type);
        Worker worker2 = CreateRandomWorker(rolledTypes);
        rolledTypes.Add(worker2.type);
        Worker worker3 = CreateRandomWorker(rolledTypes);
        rolledTypes.Add(worker3.type);

        card1.DisplayWorker(worker1, this, 1);
        card2.DisplayWorker(worker2, this, 2);
        card3.DisplayWorker(worker3, this, 3);
    }

    private Worker CreateRandomWorker(List<WorkerType> rolledTypes)
    {
        Worker worker = WorkerFactory.instance.CreateRandomWorker(rolledTypes);
        worker.transform.localScale *= 2;

        return worker;
    }

    public void GoToNextYear(int num)
    {
        WorkerType type = WorkerType.WORKER1;
        if (num == 1)
        {
            type = card1.type;
        }
        else if (num == 2)
        {
            type = card2.type;
        }
        else if (num == 3)
        {
            type = card3.type;
        }
        GlobalInfo.instance.AddWorker(type);
        SceneManager.LoadScene("Game");
    }
}
