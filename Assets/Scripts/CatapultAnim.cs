using UnityEngine;
using System.Collections;

public class CatapultAnim : MonoBehaviour {

	private CurveShot curveAnim;

	Animator anim;

	void Awake () {
		curveAnim = this.gameObject.GetComponent<CurveShot> ();
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	void Update () 
	{
		//Calls the 2 Functions everyframe.
		ShootAnimation ();
		DeathAnimation ();
	}


	//Catapult ShootAnimation function.
	void ShootAnimation()
	{
		//If the curveAnim._curveShootAnim is active, set IdleAnim false and ShootAnim True.
		if (curveAnim._curveShootAnim) 
		{
			anim.SetBool ("IdleAnim", false);
			anim.SetBool ("ShootAnim", true);
		}
		//else if the curveAnim._curveShootAnim is not active, set IdleAnim true and ShootAnim false.

		else if (!curveAnim._curveShootAnim)
		{
			anim.SetBool ("IdleAnim", true);
			anim.SetBool ("ShootAnim", false);
		}
	}

	void DeathAnimation()
	{
		/*
		 * Space for death animation!
		 * 
		 * Anim.SetBool(DeathAnim, true);
		 * Anim.SetBool(Shoot of Idle, false);
		 * 
		 */

	}
}
