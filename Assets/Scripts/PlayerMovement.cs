using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 movementVector;
    private CharacterController characterController;

    private float speed;
    private float movementSpeed = 10;

    private bool Grounded = false;
    private float minSensitivity = 0.1f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotation();        
        Movement();         
    }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movementVector = transform.TransformDirection(movementVector);
            movementVector *= speed;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            GetComponent<Rigidbody>().freezeRotation = true;  
        }

        movementVector.y -= gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
    }

    void Rotation()
    {
        if (Input.GetAxisRaw("Mouse X") > minSensitivity || Input.GetAxisRaw("Mouse X") < -minSensitivity)
        {
            playerRotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, Vector3.up);            
        }
  
        transform.rotation = playerRotation;
    }
}

        


