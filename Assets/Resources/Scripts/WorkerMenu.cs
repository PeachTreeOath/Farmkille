using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WorkerMenu : MonoBehaviour
{

    public float menuVelocity = 10f;
    private int numRow = 3;
    private List<Worker> workers;

    private float elapsedDistance;
    private bool isMoving;
    private Vector2 srcPosition;
    private Vector2 destPosition;
    private int page;

    void Update()
    {
        if (isMoving)
        {
            float moveDist = menuVelocity * Time.deltaTime;
            elapsedDistance += moveDist;
            transform.localPosition = Vector2.Lerp(srcPosition, destPosition, elapsedDistance);
            if (elapsedDistance >= 170)
            {
                isMoving = false;
            }
        }
    }

    public void PopulateWorkerMenu(List<Worker> workers)
    {
        // Workers are divided into a 3x2 menu
        int startX = 540;
        int startY = 185;
        int diffX = 170;
        int diffY = 170;

        for (int i = 0; i < workers.Count; i++)
        {
            int x = startX + diffX * (i / numRow);
            int y = startY - diffY * (i % numRow);

            workers[i].transform.localPosition = new Vector2(x, y);
        }

        WorkerArrow lArrow = CreateWorkerLeftArrow();
        WorkerArrow rArrow = CreateWorkerRightArrow();
        lArrow.transform.localPosition = new Vector2(575, -275);
        rArrow.transform.localPosition = new Vector2(675, -275);
        lArrow.menu = this;
        rArrow.menu = this;
        this.workers = workers;
    }

    public void PrevPage()
    {
        if (page == 0)
        {
            return;
        }

        isMoving = true;
        elapsedDistance = 0;
        srcPosition = transform.localPosition;
        destPosition = transform.localPosition + new Vector3(170, 0);
        page--;
    }

    public void NextPage()
    {
        if ((page-1) * numRow > GetAvailableWorkerCount())
        {
            return;
        }
        isMoving = true;
        elapsedDistance = 0;
        srcPosition = transform.localPosition;
        destPosition = transform.localPosition - new Vector3(170, 0);
        page++;
    }

    private List<Worker> CreateAvailableWorkerList()
    {
        List<Worker> newList = new List<Worker>();
        foreach (Worker worker in workers)
        {
            if (worker.hex != null)
            {
                newList.Add(worker);
            }
        }
        return newList;
    }

    private int GetAvailableWorkerCount()
    {
        int count = 0;
        foreach (Worker worker in workers)
        {
            if (worker.hex != null)
            {
                count++;
            }
        }
        return count;
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
