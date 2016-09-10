using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenDisplayer : MonoBehaviour
{
    public enum TokenLayer
    {
        UI,
        Ground,
        Invisible
    }

    private List<Token> tokens;
    private float spacing;

    public void CreateTokens(int waterValue, int fertilizerValue, int lightValue, int pesticideValue, float tokenSpacing)
    {
        tokens = new List<Token>();
        spacing = tokenSpacing;

        // Position of tokens is clockwise starting on the bottom
        if (waterValue > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(0, -tokenSpacing);
            token.SetType(ResourceType.WATER);
            tokens.Add(token);
        }

        if (fertilizerValue > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(-tokenSpacing, 0);
            token.SetType(ResourceType.FERTILIZER);
            tokens.Add(token);
        }

        if (lightValue > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(0, tokenSpacing);
            token.SetType(ResourceType.LIGHT);
            tokens.Add(token);
        }

        if (pesticideValue > 0)
        {
            Token token = Instantiate<GameObject>(PrefabManager.instance.tokenFab).GetComponent<Token>();
            token.transform.SetParent(transform);
            token.transform.localPosition = new Vector2(tokenSpacing, 0);
            token.SetType(ResourceType.PESTICIDE);
            tokens.Add(token);
        }

        SetTokenLayer(TokenLayer.Ground);
        UpdateTokens(waterValue, fertilizerValue, lightValue, pesticideValue);
    }

    public void UpdateTokens(int waterValue, int fertilizerValue, int lightValue, int pesticideValue)
    {
        foreach (Token token in tokens)
        {
            int currValue = 0;
            switch (token.type)
            {
                case ResourceType.WATER:
                    currValue = waterValue;
                    break;
                case ResourceType.FERTILIZER:
                    currValue = fertilizerValue;
                    break;
                case ResourceType.LIGHT:
                    currValue = lightValue;
                    break;
                case ResourceType.PESTICIDE:
                    currValue = pesticideValue;
                    break;
            }
            token.SetValueText(currValue);
        }
    }

    // Set token layer to be on ground vs UI
    public void SetTokenLayer(TokenLayer layer)
    {
        foreach (Token token in tokens)
        {
            string layerName = "";
            switch (layer)
            {
                case TokenLayer.UI:
                    layerName = "MenuWorker";
                    break;
                case TokenLayer.Ground:
                    layerName = "Token";
                    break;
                case TokenLayer.Invisible:
                    layerName = "Invisible";
                    break;
            }
            token.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            token.GetComponentInChildren<MeshRenderer>().sortingLayerName = layerName;
        }
    }
}
