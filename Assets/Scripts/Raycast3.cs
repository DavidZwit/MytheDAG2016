using UnityEngine;


public class Raycast3 : MonoBehaviour {
    public static float distance3 = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit,100, ~1 << 0))
        {
            distance3 = hit.distance;
            Debug.Log(distance3);            
        }	
	}
}
