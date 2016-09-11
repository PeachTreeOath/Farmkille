using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Crop : MonoBehaviour
{
    public int goldValue;

    public int waterValue;
    public int fertilizerValue;
    public int lightValue;
    public int pesticideValue;

    public int currWaterValue;
    public int currFertilizerValue;
    public int currLightValue;
    public int currPesticideValue;

    public float tokenSpacing = 0.375f;

    private TokenDisplayer tokenDisplayer;

    void Start()
    {
        ResetNeeds();
    }

    public void ResetNeeds()
    {
        currWaterValue = waterValue;
        currFertilizerValue = fertilizerValue;
        currLightValue = lightValue;
        currPesticideValue = pesticideValue;

        if (tokenDisplayer != null)
        {
            tokenDisplayer.UpdateTokens(waterValue, fertilizerValue, lightValue, pesticideValue);
        }
        else
        {
            tokenDisplayer = gameObject.AddComponent<TokenDisplayer>();
            tokenDisplayer.CreateTokens(waterValue, fertilizerValue, lightValue, pesticideValue, tokenSpacing);
        }
    }

    public void ApplyResources(Dictionary<ResourceType, int> dictionary)
    {
        int value;

        if (dictionary.TryGetValue(ResourceType.WATER, out value))
        {
            currWaterValue = Mathf.Clamp(currWaterValue - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.FERTILIZER, out value))
        {
            currFertilizerValue = Mathf.Clamp(currFertilizerValue - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.LIGHT, out value))
        {
            currLightValue = Mathf.Clamp(currLightValue - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.PESTICIDE, out value))
        {
            currPesticideValue = Mathf.Clamp(currPesticideValue - value, 0, int.MaxValue);
        }

        tokenDisplayer.UpdateTokens(currWaterValue, currFertilizerValue, currLightValue, currPesticideValue);
    }

}
