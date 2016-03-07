using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	[SerializeField]
	private Transform target;

	void Update()
	{

		transform.LookAt (target);
		transform.Rotate (Vector3.up * 90);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

	}
}