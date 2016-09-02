using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    private GameObject bgPrefab;
    private GameObject hexPrefab;
    private Transform parentTransform;

    public int bgRows;
    public int bgCols;
    public int hexRows;
    public int hexCols;

    // Use this for initialization
    void Start()
    {
        parentTransform = GameObject.Find("Terrain").transform;

        bgPrefab = PrefabManager.instance.bgFab;
        hexPrefab = PrefabManager.instance.hexFab;

        GenerateBG(bgRows, bgCols);
        GenerateHexGrid(hexRows, hexCols);
    }

    // Update is called once per frame
    void Update()
    {

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

    private void GenerateHexGrid(int row, int col)
    {
        float width = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float height = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        float startX = -(col * width) / 2;
        float startY = (row * height * 0.75f) / 2 - (0.36f * height);

        for (int i = 0; i < row; i++)
        {
            float xAdjust = 0;
            if (i % 2 == 1)
            {
                xAdjust += width * 0.5f;
            }
            for (int j = 0; j < col; j++)
            {
                Hex hex = Instantiate<GameObject>(hexPrefab).GetComponent<Hex>();
                hex.transform.SetParent(parentTransform);
                hex.row = i;
                hex.col = j;
                float xOffset = startX + width * j + xAdjust;
                float yOffset = startY - height * i * 0.75f;

                hex.transform.position = new Vector2(xOffset, yOffset);
            }
        }
    }
}
