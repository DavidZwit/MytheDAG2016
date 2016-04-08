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
    private bool Attack = false;

    private float speed;
    private float WalkSpeed = 12f;
    private float RunSpeed = 18f;
    private float turnSmoothing = 10f;
    private float rotateSpeed = 8f;
    private float speedDampTime = 0.1f;
    private float minSensitivity = 0.1f;
    private float Horizontal;
    private float Vertical;


    SoundManager sounds;

    void Awake()
    {
        speed = WalkSpeed;
        playerRigidbody = GetComponent<Rigidbody>();
        sounds = GameObject.Find("Handeler").GetComponent<SoundManager>();
        CameraTransform = GameObject.Find("Camera").transform;
        movementVector = transform.TransformDirection(Vector3.forward);
        CameraTransform = transform;
    }

    void Start()
    {
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Attack == false)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            Movement(Horizontal, Vertical);
        }

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
            _anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
            PlayAudio(12);
            movementVector = movementVector.normalized * Horizontal * speed * Time.deltaTime;
            transform.Translate(movementVector);
            return;
        }
        else if (Horizontal != 0f || Vertical != 0f)
        {
            movementVector = v * Vector3.forward;
            Rotating(h, v);
            PlayAudio(12);
            _anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
            movementVector = movementVector.normalized * Vertical * speed * Time.deltaTime;
            // Move the player to it's current position plus the movement.
            transform.Translate(movementVector);
            return;
        }
        else
        {
            _anim.SetFloat("Speed", 0);
            //PlayAudio(8);
        }

    }

    void MouseClick()
    {
        if (Attack == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayAudio(9);
                _anim.SetTrigger("Slam");
                StartCoroutine(waitImpact());
                Attack = true;
                StartCoroutine(WaitAttackDone());
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = RunSpeed;
                return;
            }
            else
            {
                speed = WalkSpeed;
            }
        }
    }

    void PlayAudio(int audioID)
    {
        sounds.PlayAudioIfNotPlaying(audioID);
    }

    void StopAudio(int audioID)
    {
        sounds.StopAudio(audioID);
    }

    IEnumerator waitImpact()
    {
        yield return new WaitForSeconds(0.5f);
        PlayAudio(5);
    }
    IEnumerator WaitAttackDone()
    {
        yield return new WaitForSeconds(1);
        Attack = false;
    }
}




