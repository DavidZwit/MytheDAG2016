using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 movementVector;
    private CharacterController characterController;

    public Animator anim;

    private float speed;
    private float movementSpeed = 10;

    private bool Grounded = false;
    private float minSensitivity = 0.5f;
    [SerializeField]
    float sensitivity = 5;

    private float gravity = 40;

    private Quaternion playerRotation;
    private float turnInput;
    private float rotateSpeed = 50f;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = movementSpeed;
        playerRotation = transform.rotation;
        anim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotation();        
        Movement();
        MouseClick();       
    }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            Vector3 keyInputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movementVector = new Vector3(keyInputs.x,0,keyInputs.z);
            movementVector = transform.TransformDirection(movementVector);
            movementVector *= speed;
            if (Input.GetAxis("Vertical") > minSensitivity || Input.GetAxis("Vertical") < -minSensitivity)
            {
                anim.SetBool("Run", true);                
                anim.SetBool("Idle", false);
            }
            else
            {
                anim.SetBool("Idle", true);
            }              

        }  
        

        movementVector.y -= gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
    }

    void Rotation()
    { 
        float inputs = Input.GetAxis("Mouse X");
        if (inputs != 0)
        {
            transform.eulerAngles += new Vector3(0, inputs * sensitivity, 0);
        }        

    }

    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Kick", true);
        }
        else
        {
            anim.SetBool("Kick", false);
        }
    }
}

        


