using UnityEngine;
using System.Collections;
using System;

public class Token : MonoBehaviour
{
    public ResourceType type;

    public Color waterColor;
    public Color fertilizerColor;
    public Color lightColor;
    public Color pesticideColor;

    private TextMesh text;

    public void SetType(ResourceType newType)
    {
        text = GetComponentInChildren<TextMesh>();
        type = newType;
        SetColor();
    }

    public void SetValueText(int value)
    {
        text.text = value + "";
    }

    private void SetColor()
    {
        Color newColor = Color.clear;
        switch (type)
        {
            case ResourceType.WATER:
                newColor = waterColor;
                break;
            case ResourceType.FERTILIZER:
                newColor = fertilizerColor;
                break;
            case ResourceType.LIGHT:
                newColor = lightColor;
                break;
            case ResourceType.PESTICIDE:
                newColor = pesticideColor;
                break;
            default:
                break;
        }
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
