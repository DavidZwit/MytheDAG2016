using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Vector3 movePos, mouseMove;
    SwordAttack swordScript;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float sensitivity;

    void Awake()
    {
        swordScript = GameObject.Find("Bat").GetComponent<SwordAttack>();
    }

    void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (inputs.x != 0) {
            transform.eulerAngles += new Vector3(-inputs.y * sensitivity, inputs.x * sensitivity);
        }

        if (Input.GetKey(KeyCode.W)) movePos.z++;
        if (Input.GetKey(KeyCode.S)) movePos.z--;
        if (Input.GetKey(KeyCode.A)) movePos.x--;
        if (Input.GetKey(KeyCode.D)) movePos.x++;

        transform.Translate(Vector3.forward * (movePos.z * moveSpeed * Time.deltaTime));
        transform.Translate(Vector3.right * (movePos.x * moveSpeed * Time.deltaTime));
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        movePos = new Vector3();

        if (Input.GetMouseButtonDown(0)) Atack();
    }

    void Atack()
    {
        swordScript.Attack();
    }
}
