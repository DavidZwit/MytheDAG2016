using UnityEngine;
using System.Collections;

public class EventHandeler : MonoBehaviour {

    RandomShake screenShake;

    void Awake()
    {
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
    }

	public void SomethingBroke(Collision coll)
    {
        //add score
        screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
    }
}
