using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float xSpeed = 10f;
    public float ySpeed = 10f;
    public float yMinLimit = -20;
    public float yMaxLimit = 80;
    public float x = 0f;
    public float y = 0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            x += Input.GetAxisRaw("Mouse X") * xSpeed;
            y -= Input.GetAxisRaw("Mouse Y") * xSpeed;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

            distance = Raycast3.distance3;
            if (distance < 10 )
            {
                distance = 10;
            }

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
