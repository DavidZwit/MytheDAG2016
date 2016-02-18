using UnityEngine;
using System.Collections;

public class PlayStuff : MonoBehaviour {
	
	void OnTriggerEnter(Collider col)
	{
			Destroy (this.gameObject);
			print ("Dat voelt lekker");
	}
}
