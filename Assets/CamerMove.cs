using UnityEngine;
using System.Collections;

public class CamerMove : MonoBehaviour {
    private float minSensitivity = 0.2f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
	}

    void Rotation()
    {
        float inputs = Input.GetAxis("Mouse Y");
        if (inputs != 0)
        {
            transform.eulerAngles += new Vector3(-inputs * minSensitivity,0, 0);
        }

    }
}
