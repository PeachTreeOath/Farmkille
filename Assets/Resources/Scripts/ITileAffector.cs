using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ITileAffector
{
    // Return a list of tiles the worker affects in relation to its position
    List<GameManager.Key> GetAffectedTiles(Hex originHex);
}
