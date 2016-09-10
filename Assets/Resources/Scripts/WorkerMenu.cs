using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WorkerMenu : MonoBehaviour
{

    private List<Worker> workers;

    public void CreateWorkerMenu(List<Worker> workers)
    {
        // Workers are divided into a 3x2 menu
        int startX = 540;
        int startY = 185;
        int diffX = 170;
        int diffY = 170;

        for (int i = 0; i < workers.Count; i++)
        {
            int x = startX + diffX * (i / 3);
            int y = startY - diffY * (i % 3);

            workers[i].transform.localPosition = new Vector2(x, y);
        }

        WorkerArrow lArrow = CreateWorkerLeftArrow();
        WorkerArrow rArrow = CreateWorkerRightArrow();
        lArrow.transform.localPosition = new Vector2(575, -275);
        rArrow.transform.localPosition = new Vector2(675, -275);

        this.workers = workers;
    }

    public void PrevPage()
    {
        foreach (Worker worker in workers)
        {
            worker.transform.localPosition -= new Vector3(100, 0);
        }
    }

    public void NextPage()
    {
        throw new NotImplementedException();
    }

    private WorkerArrow CreateWorkerLeftArrow()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerArrowFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        WorkerArrow arrow = obj.GetComponent<WorkerArrow>();
        arrow.FaceLeft();
        return arrow;
    }

    private WorkerArrow CreateWorkerRightArrow()
    {
        GameObject obj = Instantiate<GameObject>(PrefabManager.instance.workerArrowFab);
        obj.transform.SetParent(GameManager.instance.canvas.transform);
        WorkerArrow arrow = obj.GetComponent<WorkerArrow>();
        return arrow;
    }
}
