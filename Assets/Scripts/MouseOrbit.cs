using UnityEngine;


public class MouseOrbit : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    private float Distance;
    private float setDistance = 20f;
    private float SpeedX = 10f;
    private float SpeedY = 10f;
    private float MinLimitY = -5;
    private float MaxLimitY = 60;
    private float X = 0f;
    private float Y = 0f;

    void Awake()
    {
        Target = GameObject.Find("CameraReference").transform;
    }

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        X = angles.y;
        Y = angles.x;

        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(distance);
        Distance = Raycast3.distance3;
        if (Distance > setDistance)
        {
            Distance = setDistance;
        }

        if (Target)
        {
            X += Input.GetAxisRaw("Mouse X") * SpeedX;
            Y -= Input.GetAxisRaw("Mouse Y") * SpeedY;

            Y = ClampAngle(Y, MinLimitY, MaxLimitY);

            Quaternion rotation = Quaternion.Euler(Y, X, 0);

            Vector3 position = rotation * new Vector3(0, 0, -Distance) + Target.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1.0f * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Linecast(Target.position, transform.position, out hit))
            {
                Distance -= hit.distance;
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
