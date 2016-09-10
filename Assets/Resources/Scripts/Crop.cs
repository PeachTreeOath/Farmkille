using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Crop : MonoBehaviour
{

    public float tokenSpacing = 0.375f;

    public int waterNeed;
    public int fertilizerNeed;
    public int lightNeed;
    public int pesticideNeed;

    public int currWaterNeed;
    public int currFertilizerNeed;
    public int currLightNeed;
    public int currPesticideNeed;

    private List<Token> tokens;

    // Use this for initialization
    void Start()
    {
        tokens = new List<Token>();
        ResetNeeds();
        CreateTokens();
    }

    public void ResetNeeds()
    {
        currWaterNeed = waterNeed;
        currFertilizerNeed = fertilizerNeed;
        currLightNeed = lightNeed;
        currPesticideNeed = pesticideNeed;
    }

    public void ApplyResources(Dictionary<ResourceType, int> dictionary)
    {
        int value;

        if (dictionary.TryGetValue(ResourceType.WATER, out value))
        {
            currWaterNeed = Mathf.Clamp(currWaterNeed - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.FERTILIZER, out value))
        {
            currFertilizerNeed = Mathf.Clamp(currFertilizerNeed - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.LIGHT, out value))
        {
            currLightNeed = Mathf.Clamp(currLightNeed - value, 0, int.MaxValue);
        }

        if (dictionary.TryGetValue(ResourceType.PESTICIDE, out value))
        {
            currPesticideNeed = Mathf.Clamp(currPesticideNeed - value, 0, int.MaxValue);
        }

        UpdateTokens();
    }

    private void CreateTokens()
    {
        // Position of tokens is clockwise starting on the bottom
        if (waterNeed > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(0, -tokenSpacing);
            token.SetType(ResourceType.WATER);
            tokens.Add(token);
        }

        if (fertilizerNeed > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(-tokenSpacing, 0);
            token.SetType(ResourceType.FERTILIZER);
            tokens.Add(token);
        }

        if (lightNeed > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(0, tokenSpacing);
            token.SetType(ResourceType.LIGHT);
            tokens.Add(token);
        }

        if (pesticideNeed > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(tokenSpacing, 0);
            token.SetType(ResourceType.PESTICIDE);
            tokens.Add(token);
        }

        UpdateTokens();
    }

    private void UpdateTokens()
    {
        foreach (Token token in tokens)
        {
            int currNeed = 0;
            switch (token.type)
            {
                case ResourceType.WATER:
                    currNeed = currWaterNeed;
                    break;
                case ResourceType.FERTILIZER:
                    currNeed = currFertilizerNeed;
                    break;
                case ResourceType.LIGHT:
                    currNeed = currLightNeed;
                    break;
                case ResourceType.PESTICIDE:
                    currNeed = currPesticideNeed;
                    break;
            }
            token.SetValueText(currNeed);
        }
    }
}
