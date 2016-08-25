using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    private GameObject hexPrefab;
    private Transform parentTransform;

    // Use this for initialization
    void Start()
    {
        hexPrefab = Resources.Load<GameObject>("Prefabs/Hex");
        parentTransform = GameObject.Find("Terrain").transform;

        GenerateHexGrid(5, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateHexGrid(int row, int col)
    {
        float width = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float height = hexPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float startX = -(row * width) / 2;
        float startY = (col * height) / 2;
                
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Hex hex = Instantiate<GameObject>(hexPrefab).GetComponent<Hex>();
                hex.transform.SetParent(parentTransform);
                hex.row = i;
                hex.col = j;
                float xOffset = startX + width * j * 0.75f;
                float yOffset = startY - height * i * 0.8f;
                if(j % 2 == 1)
                {
                    yOffset -= height * 0.4f;
                }
                hex.transform.position = new Vector2(xOffset, yOffset);
            }
        }
    }
}
