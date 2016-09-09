using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RadialTileAffector : MonoBehaviour, ITileAffector
{

    public int size;

    public List<GameManager.Key> GetAffectedTiles(Hex originHex)
    {
        List<GameManager.Key> tileList = new List<GameManager.Key>();
        Dictionary<GameManager.Key, Hex> grid = GameManager.instance.grid;
        foreach (var key in grid.Keys)
        {
            int distance = Hex.HexDistance(originHex, grid[key]);
            if (distance <= size && distance != 0)
            {
                tileList.Add(key);
            }
        }
        
        return tileList;
    }
}
