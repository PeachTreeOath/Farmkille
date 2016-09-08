using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class AbstractTileAffector : MonoBehaviour {

    // Return a list of tiles the worker affects in relation to its position
    abstract public List<Vector2> GetAffectedTiles();

    // Return a map of resources and the levels the worker provides
    abstract public Dictionary<ResourceType, int> GetProductionMap();
}
