using UnityEngine;
using System.Collections;

public class FireParticle : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
