using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{

    private Vector3 movementVector = Vector3.zero;
    private Rigidbody playerRigidbody;
    public Animator _anim;
    [SerializeField]
    private float turnSmoothing = 15f;
    [SerializeField]
    private float speedDampTime = 0.1f;


    private float speed;
    private float movementSpeed = 10f;

    private bool Grounded = false;
    private float minSensitivity = 0.5f;

    private float gravity = 40;
    private bool isMoving = false;
    private Quaternion playerRotation;
    private float turnInput;
    [SerializeField]
    private float rotateSpeed = 10f;
    private float Horizontal;
    private float Vertical;

    private Vector3 targetDirection;

    public Transform _camera;
    private Vector3 CamDirection;
    // Use this for initialization

    void Awake()
    {
        movementVector = transform.TransformDirection(Vector3.forward);
        _camera = transform;
    }

    void Start()
    {
        Cursor.visible = false;
        speed = movementSpeed;
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Movement(Horizontal,Vertical);
       
        MouseClick();
       // Animator();
    }

    /*void Movement(float h,float v)
    {
        if (_camera != null)
        {
            // calculate camera relative direction to move
            CamDirection = Vector3.Scale(_camera.forward, new Vector3(1, 0, 1)).normalized;
            movementVector = v * CamDirection + h * _camera.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            movementVector = v * Vector3.forward + h * Vector3.right;
        }
        // Normalise the movement vector and make it proportional to the speed per second.
        movementVector = movementVector.normalized *  speed * Time.deltaTime;
        // Move the player to it's current position plus the movement.
        transform.Translate(movementVector);
        if (Horizontal != 0f || Vertical != 0f)
        {
            // ... set the players rotation and set the speed parameter to 5.3f.
            Rotating(h, v);
            _anim.SetFloat("Speed", 1f, speedDampTime, Time.deltaTime);
        }
        else
            // Otherwise set the speed parameter to 0.
            _anim.SetFloat("Speed", 0);
    }*/


    void Rotating(float h, float v)
    {
        // Create a new vector of the horizontal and vertical inputs.
        targetDirection = new Vector3(h, 0f, v);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        playerRigidbody.MoveRotation(newRotation);

        
    
    }

    void Animator()
    { 

    }



    void Movement(float h, float v)
    {
        movementVector = v * Vector3.forward;
        //Debug.Log(v * Vector3.forward + h * Vector3.right);
        if (Horizontal != 0f || Vertical != 0f)
        {
            // ... set the players rotation and set the speed parameter to 5.3f.
            Rotating(h, v);
            _anim.SetFloat("Speed", 1f, speedDampTime, Time.deltaTime);
            
        }
        else {
            // Otherwise set the speed parameter to 0.
            _anim.SetFloat("Speed", 0);
        }

        movementVector = movementVector.normalized * Vertical * speed * Time.deltaTime;
        // Move the player to it's current position plus the movement.
        transform.Translate(movementVector);
    }

    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            _anim.SetTrigger("Smash");
        }
    }

    
}

        


