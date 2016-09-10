using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceProducer : MonoBehaviour
{

    public float tokenSpacing = 0.375f;

    public int waterValue;
    public int fertilizerValue;
    public int lightValue;
    public int pesticideValue;

    private Dictionary<ResourceType, int> productionMap;
    private TokenDisplayer tokenDisplayer;

    void Awake()
    {
        productionMap = new Dictionary<ResourceType, int>();
        productionMap.Add(ResourceType.WATER, waterValue);
        productionMap.Add(ResourceType.FERTILIZER, fertilizerValue);
        productionMap.Add(ResourceType.LIGHT, lightValue);
        productionMap.Add(ResourceType.PESTICIDE, pesticideValue);

        tokenDisplayer = gameObject.AddComponent<TokenDisplayer>();
        tokenDisplayer.CreateTokens(waterValue, fertilizerValue, lightValue, pesticideValue, tokenSpacing);
        // TODO: Make sure update token is called if unit is buffed/debuffed
    }

    // Return the value of the resource in the map
    public int GetProductionValue(ResourceType type)
    {
        int val = 0;
        productionMap.TryGetValue(type, out val);
        return val;
    }

    public Dictionary<ResourceType, int> GetProductionMap()
    {
        return productionMap;
    }

    public void SetTokenLayer(TokenDisplayer.TokenLayer layer)
    {
        tokenDisplayer.SetTokenLayer(layer);
    }
}
