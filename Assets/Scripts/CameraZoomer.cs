using UnityEngine;
using System.Collections;

public class CameraZoomer : MonoBehaviour {

    public float scrollSpeed = 30;
    float newZ, distance;

	void Update () {
        float wheel = Input.GetAxis("Mouse ScrollWheel");

        if (wheel > 0f || wheel < 0f && transform.position.z + wheel < 1)
            newZ = transform.position.z + wheel; distance = transform.position.z - newZ;

        if (distance > 0.1f || distance < 0.1f)
            transform.Translate(Vector3.back * distance / scrollSpeed);
    }
}
