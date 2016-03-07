using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{

    private Vector3 movementVector;
    private Rigidbody playerRigidbody;
    public Animator _anim;

    private float speed;
    private float movementSpeed = 10f;

    private bool Grounded = false;
    private float minSensitivity = 0.5f;

    private float gravity = 40;

    private Quaternion playerRotation;
    private float turnInput;
    [SerializeField]
    private float rotateSpeed = 10f;
    private float Horizontal;
    private float Vertical;
    // Use this for initialization
    void Start()
    {
        speed = movementSpeed;
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        

        Movement();
        MouseClick();
        Animator();
    }

    void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        // Set the movement vector based on the axis input.
        movementVector.Set(0f, 0f, Vertical);
        // Normalise the movement vector and make it proportional to the speed per second.
        movementVector = movementVector.normalized * speed * Time.deltaTime;    
        transform.Translate(movementVector);
        // Move the player to it's current position plus the movement.
        //playerRigidbody.MovePosition(transform.position + movementVector);
        //playerRigidbody.MoveRotation(transform.rotation);
        if (Horizontal > minSensitivity || Horizontal < -minSensitivity)
        {
            transform.eulerAngles += new Vector3(0, Horizontal * rotateSpeed, 0);
        }
    }

    void Animator()
    {   bool walking;
        if (walking = Horizontal != 0f || Vertical != 0f)
        {
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }

    }


   /* void Movement()
    {
        
        movementVector = new Vector3(0, 0, keyInputs.z);
        movementVector = transform.TransformDirection(movementVector);
        movementVector *= speed;

        if (Input.GetAxis("Vertical") > minSensitivity || Input.GetAxis("Vertical") < -minSensitivity)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (keyInputs.x > minSensitivity || keyInputs.x < -minSensitivity)
        {
            transform.eulerAngles += new Vector3(0, keyInputs.x * rotateSpeed, 0);
        }



    }*/

    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            _anim.SetTrigger("Smash");
        }
    }
}

        


