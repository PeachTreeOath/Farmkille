﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{

    private Transform parentTransform;

    private GameObject bgPrefab;
    private GameObject hexPrefab;
    private GameObject hexTransparentPrefab;

    public int bgRows;
    public int bgCols;

    // Use this for initialization
    void Start()
    {
        parentTransform = GameObject.Find("Terrain").transform;

        bgPrefab = PrefabManager.instance.bgFab;
        hexPrefab = PrefabManager.instance.hexFab;
        hexTransparentPrefab = PrefabManager.instance.hexTransparentFab;

        GenerateBG(bgRows, bgCols);
        GenerateHexGrid(GameManager.instance.hexRadius);
        GameManager.instance.StartGame();
    }

    private void GenerateBG(int row, int col)
    {
        Vector2 size = bgPrefab.GetComponent<SpriteRenderer>().bounds.size;

        float startX = (size.x * col * -.5f) + size.x / 2;
        float startY = (size.y * row * .5f) - size.y / 2;
        float currX = startX;
        float currY = startY;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject bg = Instantiate<GameObject>(bgPrefab);
                bg.transform.SetParent(parentTransform);
                bg.transform.position = new Vector2(currX, currY);
                currX += size.x;
            }
            currY -= size.y;
            currX = startX;
        }
    }

    private void GenerateHexGrid(int radius)
    {
        Dictionary<GameManager.Key, Hex> grid = new Dictionary<GameManager.Key, Hex>();

        float width = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float height = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = -radius; i <= radius; i++)
        {
            int j1 = Mathf.Max(-radius, -i - radius);
            int j2 = Mathf.Min(radius, -i + radius);
            for (int j = j1; j <= j2; j++)
            {
                GameObject hexTransparent = Instantiate<GameObject>(hexTransparentPrefab);
                hexTransparent.transform.SetParent(parentTransform);

                Hex hex = Instantiate<GameObject>(hexPrefab).GetComponent<Hex>();
                hex.transform.SetParent(parentTransform);
                hex.SetCoords(i, j);

                float xOffset = (i - j) * width * 0.5f;
                float yOffset = (i + j) * height * 0.75f;

                hexTransparent.transform.position = new Vector2(xOffset, yOffset);
                hex.transform.position = new Vector2(xOffset, yOffset);
                grid[new GameManager.Key(i, j)] = hex;
            }
        }

        GameManager.instance.grid = grid;
    }
}
