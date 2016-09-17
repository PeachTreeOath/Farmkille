using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float speed = 7f;
    public Vector2 ulBounds;
    public Vector2 brBounds;

    // Update is called once per frame
    void Update()
    {
        float delta = speed * Time.deltaTime;
        transform.position += new Vector3(Input.GetAxis("Horizontal") * delta, Input.GetAxis("Vertical") * delta);
        if (transform.position.x < ulBounds.x)
        {
            transform.position = new Vector3(ulBounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > brBounds.x)
        {
            transform.position = new Vector3(brBounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > ulBounds.y)
        {
            transform.position = new Vector3(transform.position.x, ulBounds.y, transform.position.z);
        }
        if (transform.position.y < brBounds.y)
        {
            transform.position = new Vector3(transform.position.x, brBounds.y, transform.position.z);
        }
    }
}
