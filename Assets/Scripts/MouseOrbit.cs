using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{
    public Transform target;
    private float distance;
    public float setDistance = 0.1f;
    public float xSpeed = 10f;
    public float ySpeed = 10f;
    public float yMinLimit = -10;
    public float yMaxLimit = 60;
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
        Debug.Log(distance);
        distance = Raycast3.distance3;
        if (distance > setDistance)
        {
            distance = setDistance;
        }

        if (target)
        {
            x += Input.GetAxisRaw("Mouse X") * xSpeed;
            y -= Input.GetAxisRaw("Mouse Y") * xSpeed;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;


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
