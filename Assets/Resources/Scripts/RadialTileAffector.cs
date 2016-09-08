using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RadialTileAffector : MonoBehaviour, ITileAffector
{

    public int size;

    public List<GameManager.Key> GetAffectedTiles()
    {
        List<GameManager.Key> tileList = new List<GameManager.Key>();

        //TODO Temp
        tileList.Add(new GameManager.Key(-1, 0));
        tileList.Add(new GameManager.Key(-1, 1));
        tileList.Add(new GameManager.Key(0, -1));
        tileList.Add(new GameManager.Key(0, 1));
        tileList.Add(new GameManager.Key(1, -1));
        tileList.Add(new GameManager.Key(1, 0));

        return tileList;
    }
}
