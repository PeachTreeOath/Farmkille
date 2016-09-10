using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Crop : MonoBehaviour
{

    public int waterNeed;
    public int fertilizerNeed;
    public int lightNeed;

    public int currWaterNeed;
    public int currFertilizerNeed;
    public int currLightNeed;

    // Use this for initialization
    void Start()
    {
        ResetNeeds();
    }

    public void ResetNeeds()
    {
        currWaterNeed = waterNeed;
        currFertilizerNeed = fertilizerNeed;
        currLightNeed = lightNeed;
    }

    public void ApplyResources(Dictionary<ResourceType, int> dictionary)
    {
        int value;

        if(dictionary.TryGetValue(ResourceType.WATER, out value))
        {
            currWaterNeed -= value;
        }

        if (dictionary.TryGetValue(ResourceType.FERTILIZER, out value))
        {
            currFertilizerNeed -= value;
        }

        if (dictionary.TryGetValue(ResourceType.LIGHT, out value))
        {
            currLightNeed -= value;
        }
    }
}
