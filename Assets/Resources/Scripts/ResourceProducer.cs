using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceProducer : MonoBehaviour {

    public int waterValue;
    public int fertilizerValue;
    public int lightValue;

    private Dictionary<ResourceType, int> productionMap;

    void Start()
    {
        SetProductionMap();
    }

    public void SetProductionMap()
    {

    }

    // Return the value of the resource in the map
    public int GetProductionValue(ResourceType type)
    {
        int val = 0;
        productionMap.TryGetValue(type, out val);
        return val;
    }
}
