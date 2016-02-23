using UnityEngine;
using System.Collections;

public class ChangeToBrokenModelOnCollisionWith : MonoBehaviour {

    [SerializeField]
    GameObject brokenVersion;
    EventHandeler eventHandeler;

    void Awake()
    {
        eventHandeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
        eventHandeler.BreakableObjects++;
    }

    public void Break()
    {
        eventHandeler.BreakableObjects--;
        Instantiate(brokenVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
