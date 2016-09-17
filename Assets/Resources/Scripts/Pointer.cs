using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Vector2 origPos;

    // Use this for initialization
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(origPos.x + Mathf.Abs(Mathf.Sin(Time.time * 5)), origPos.y);
    }

    public void ShowArrow(bool show)
    {
        sprite.enabled = show;
    }
}
