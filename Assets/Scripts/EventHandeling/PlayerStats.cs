using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    EventHandeler handeler;

    void Awake()
    {
        handeler = GameObject.Find("Handeler").GetComponent<EventHandeler>();
    }

    public void BrokeSomething(Collision coll)
    {
        handeler.SomethingBroke(coll);
    }
}
