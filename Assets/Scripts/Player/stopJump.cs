using UnityEngine;
using System.Collections;

public class stopJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
	}
}
