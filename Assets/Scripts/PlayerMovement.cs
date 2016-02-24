using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 movementVector;
    public Animator anim;

    private float speed;
    private float movementSpeed = 10f;

    private bool Grounded = false;
    private float minSensitivity = 0.5f;

    private float gravity = 40;

    private Quaternion playerRotation;
    private float turnInput;
    [SerializeField]
    private float rotateSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();

        speed = movementSpeed;
        playerRotation = transform.rotation;
       // anim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {               
        Movement();
        MouseClick();       
    }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            Vector3 keyInputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movementVector = new Vector3(0,0,keyInputs.z);
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
            if (keyInputs.x > minSensitivity || keyInputs.x <-minSensitivity)
            {
                transform.eulerAngles += new Vector3(0, keyInputs.x * rotateSpeed, 0);
            }             

        }  
        

        movementVector.y -= gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
    }

    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
           anim.SetTrigger("Smash");
        }
    }
}

        


