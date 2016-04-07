using UnityEngine;
using System.Collections;

public class killEnemies : MonoBehaviour
{
    [SerializeField]
    private Transform cube;
    public bool _knockup;
    private EventHandeler events;
    private GameObject handler;

    void Awake()
    {
        handler = GameObject.Find("Handeler");
        events = handler.GetComponent<EventHandeler>();
        _knockup = false;
    }

    public void attacking()
    {
        //print("seconds test 2");
        Collider[] hitColliders = Physics.OverlapSphere(cube.position, 5);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Breakable")
            {
                //print("shrekt");
                events.SomethingBroke(hitColliders[i].gameObject);
            }
            IDamageable damageableObject = hitColliders[i].GetComponent<IDamageable>();
            if (damageableObject != null)//"if object has idamagable"
            {
                damageableObject.TakeDamg(100);//damage it
            }
        }
        /*Collider[] knockColliders = Physics.OverlapSphere(cube.position, 8);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody knockObject = knockColliders[i].GetComponent<Rigidbody>();
            if (knockObject != null)//"if object has idamagable"
            {
                knockObject.AddExplosionForce(25,cube.position,15);//damage it
            }
        }*/
    }
    public void knockups()
    {
        _knockup = !_knockup;
        print(_knockup);
        cube.GetComponent<SphereCollider>().enabled = _knockup;
    }
}