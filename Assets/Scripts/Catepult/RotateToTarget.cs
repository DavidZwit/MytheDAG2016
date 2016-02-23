using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	[SerializeField] private Transform target;

	void Update()
	{
		//With lookAt target the catapult will follow the given target.
		transform.LookAt (target);

		//it will turn a 90 degrees angle because the model had some Rotation issues while the catapult was looking at the target.
		transform.Rotate (Vector3.up * 90);

		//The catapult will be locked on the horizontal axis.
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

	}
}