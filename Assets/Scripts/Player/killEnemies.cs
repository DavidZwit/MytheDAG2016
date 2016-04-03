using UnityEngine;
using System.Collections;

public class killEnemies : MonoBehaviour {
    [SerializeField]
    private float timer;
    
    void FixedUpdate()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("attacking", timer);
            //StartCoroutine("attacking");
            print("seconds test 1");
        }
    }

    void attacking()
    {
        print("seconds test 2");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            IDamageable damageableObject =  hitColliders[i].GetComponent<IDamageable>();
            if (damageableObject != null)//"if object has idamagable"
            {
                damageableObject.TakeDamg(100);//damage it
            }
        }
    }
}
