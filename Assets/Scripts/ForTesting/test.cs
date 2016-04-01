using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine("checkForPlayer");

    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("checkForPlayer");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("checkForPlayer");
        }
    }
        IEnumerator checkForPlayer()
    {
        while (true)
        {
            //print("test");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
