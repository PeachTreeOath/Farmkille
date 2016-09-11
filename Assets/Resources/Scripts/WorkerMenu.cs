using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//TODO: Make worker menu dynamic instead of having empty slots when you deploy
public class WorkerMenu : MonoBehaviour
{

    public float menuVelocity = 10f;
    private int numRows = 3;
    private List<Worker> workers;

    private float elapsedDistance;
    private bool isMoving;
    private Vector2 srcPosition;
    private Vector2 destPosition;
    private int page;

    private WorkerArrow lArrow;
    private WorkerArrow rArrow;

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
            int x = startX + diffX * (i / numRows);
            int y = startY - diffY * (i % numRows);

            workers[i].transform.localPosition = new Vector2(x, y);
        }

        lArrow = CreateWorkerLeftArrow();
        rArrow = CreateWorkerRightArrow();
        lArrow.transform.localPosition = new Vector2(575, -275);
        rArrow.transform.localPosition = new Vector2(675, -275);
        lArrow.menu = this;
        rArrow.menu = this;
        this.workers = workers;
        CheckIfArrowAllowed();
    }

    public void PrevPage()
    {
        isMoving = true;
        elapsedDistance = 0;
        srcPosition = transform.localPosition;
        destPosition = transform.localPosition + new Vector3(170, 0);
        page--;
        CheckIfArrowAllowed();
        ShowHideWorkers();
    }

    public void NextPage()
    {
        isMoving = true;
        elapsedDistance = 0;
        srcPosition = transform.localPosition;
        destPosition = transform.localPosition - new Vector3(170, 0);
        page++;
        CheckIfArrowAllowed();
        ShowHideWorkers();
    }

    private void CheckIfArrowAllowed()
    {
        if (page == 0)
        {
            lArrow.SetEnabled(false);
        }
        else
        {
            if (!lArrow.isEnabled)
            {
                lArrow.SetEnabled(true);
            }
        }

        // Check if there's any workers after current page
        //TODO: Change if menu becomes dynamic
        //int count = GetAvailableWorkerCount() - 3 - (page + 1) * numRows;
        int count = workers.Count - 3 - (page + 1) * numRows;
        if (count <= 0)
        {
            rArrow.SetEnabled(false);
        }
        else
        {
            if (!rArrow.isEnabled)
            {
                rArrow.SetEnabled(true);
            }
        }
    }

    private List<Worker> CreateAvailableWorkerList()
    {
        List<Worker> newList = new List<Worker>();
        foreach (Worker worker in workers)
        {
            if (worker.hex == null)
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
            if (worker.hex == null)
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

    private void ShowHideWorkers()
    {
        //TODO: Change if dynamic
        /*
        List<Worker> availableWorkers = CreateAvailableWorkerList();
        int invisIndex = page * numRows;

        for (int i = 0; i < availableWorkers.Count; i++)
        {
            Worker worker = availableWorkers[i];
            if (i < invisIndex)
            {
                worker.SetEnabled(false);
            }
            else
            {
                worker.SetEnabled(true);
            }
        }
        */
        int invisIndex = page * numRows;

        for (int i = 0; i < workers.Count; i++)
        {
            Worker worker = workers[i];
            if (worker.hex == null)
            {
                continue;
            }

            if (i < invisIndex)
            {
                worker.SetEnabled(false);
            }
            else
            {
                worker.SetEnabled(true);
            }
        }
    }
}
