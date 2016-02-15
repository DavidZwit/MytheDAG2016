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
        mouseMove = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (mouseMove.x > 0 || mouseMove.x < 0)
            transform.Rotate(Vector3.up * (mouseMove.x * sensitivity));
        if (mouseMove.y > 0 || mouseMove.y < 0)
            transform.Rotate(Vector3.right * -(mouseMove.y * sensitivity));

        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

        if (Input.GetKey(KeyCode.W)) movePos.z++;
        if (Input.GetKey(KeyCode.S)) movePos.z--;
        if (Input.GetKey(KeyCode.A)) movePos.x--;
        if (Input.GetKey(KeyCode.D)) movePos.x++;

        transform.Translate(Vector3.forward * (movePos.z * moveSpeed));
        transform.Translate(Vector3.right * (movePos.x * moveSpeed));
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        movePos = new Vector3();

        if (Input.GetMouseButtonDown(0)) Atack();
    }

    void Atack()
    {
        swordScript.Attack();
    }
}
