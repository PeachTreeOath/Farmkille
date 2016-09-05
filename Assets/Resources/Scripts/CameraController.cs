using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float speed = 7f;

    // Update is called once per frame
    void Update()
    {
        float delta = speed * Time.deltaTime;
        transform.position += new Vector3(Input.GetAxis("Horizontal") * delta, Input.GetAxis("Vertical") * delta);
    }
}
