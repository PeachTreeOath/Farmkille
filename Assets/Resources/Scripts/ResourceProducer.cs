using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ResourceProducer {

    protected Dictionary<ResourceType, int> productionMap;

    void Start()
    {
        SetProductionMap();
    }

    // Set up production values in Start()
    abstract protected void SetProductionMap();

    // Return a map of resources and the levels the worker provides
    public Dictionary<ResourceType, int> GetProductionMap()
    {
        return productionMap;
    }
}
