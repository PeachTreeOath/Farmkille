using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float speed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }
}
