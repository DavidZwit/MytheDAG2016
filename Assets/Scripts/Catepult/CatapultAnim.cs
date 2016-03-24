using UnityEngine;
using System.Collections;

public class CatapultAnim : MonoBehaviour {

	private CurveShot curveAnim;

	Animator anim;

	// Use this for initialization
	void Start () {
		curveAnim = this.gameObject.GetComponent<CurveShot> ();
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ShootAnimation ();
		DeathAnimation ();
	}

	void ShootAnimation()
	{
		if (curveAnim._curveShootAnim) 
		{
			anim.SetBool ("IdleAnim", false);
			anim.SetBool ("ShootAnim", true);
		}
		
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
