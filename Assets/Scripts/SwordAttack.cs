using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

    float attackSpeed = 0.5f;
    bool attacking, back = false;

	public void Attack()
    {
        attacking = true;
        back = false;
    }

    void Update ()
    {
        if (attacking) {
            if (!back) {
                if (transform.localPosition.x > -1)  {
                    transform.Translate(Vector3.left * attackSpeed);
                } else back = true;
            } else if (transform.localPosition.x < 0.60f) { 
                transform.Translate(Vector3.right * attackSpeed);
            } else attacking = false;

            transform.rotation = new Quaternion(35, transform.rotation.y + transform.rotation.x * 0.02f, 10, 70 );
            transform.localPosition = new Vector3(transform.localPosition.x, 0.3f, 1.2f);
        }
    }
}
