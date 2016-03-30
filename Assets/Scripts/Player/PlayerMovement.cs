using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 movementVector = Vector3.zero;
    private Vector3 CamDirection;
    private Vector3 targetDirection;
    private Quaternion playerRotation;
    private Transform CameraTransform;
    private Rigidbody playerRigidbody;
    public Animator _anim;

    private bool AudioPlays = false;

    private float MovementSpeed = 12f;
    private float turnSmoothing = 10f;
    private float rotateSpeed = 8f;
    private float speedDampTime = 0.1f;
    private float minSensitivity = 0.1f;
    private float Horizontal;
    private float Vertical;


    private GameObject handler;




    // Use this for initialization

    void Awake()
    {
        handler = GameObject.Find("Handeler");
        CameraTransform = GameObject.Find("Camera").transform;
        movementVector = transform.TransformDirection(Vector3.forward);
        CameraTransform = transform;
    }

    void Start()
    {
        Cursor.visible = false;
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Movement(Horizontal, Vertical);

        MouseClick();
    }


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


    void Movement(float h, float v)
    {
        if (Horizontal != 0f && Vertical == 0f)
        {
            movementVector = h * Vector3.forward;
            Rotating(h, v);
            _anim.SetFloat("Speed", 1f, speedDampTime, Time.deltaTime);
            PlayAudio(6);
            movementVector = movementVector.normalized * Horizontal * MovementSpeed * Time.deltaTime;
            transform.Translate(movementVector);
            return;
        }
        else if (Horizontal != 0f || Vertical != 0f)
        {
            movementVector = v * Vector3.forward;
            Rotating(h, v);
            PlayAudio(6);
            _anim.SetFloat("Speed", 1f, speedDampTime, Time.deltaTime);
            movementVector = movementVector.normalized * Vertical * MovementSpeed * Time.deltaTime;
            // Move the player to it's current position plus the movement.
            transform.Translate(movementVector);
            return;
        }
        else
        {
            StopAudio(6);
            _anim.SetFloat("Speed", 0);
        }

    }

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("Smash");
            PlayAudio(10);
        }
    }

    void PlayAudio(int audioID)
    {
        handler.GetComponent<SoundManager>().PlayAudioIfNotPlaying(audioID);
    }

    void StopAudio(int audioID)
    {
        handler.GetComponent<SoundManager>().StopAudio(audioID);
    }
}




