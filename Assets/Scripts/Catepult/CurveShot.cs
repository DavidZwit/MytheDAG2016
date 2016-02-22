using UnityEngine;
using System.Collections;

public class CurveShot : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float firingAngle = 45.0f;
	[SerializeField] private float gravity = 9.8f;
	[SerializeField] private float delayTime = 1f;
	[SerializeField] private GameObject nozzle;
	[SerializeField] private Transform projectile;      
	private Transform myCatapult;

	public bool _curveShootAnim = false;

	void Awake()
	{
		myCatapult = transform; 

		//With the invokeReapeat whe can shoot more then 1 projectile.
		InvokeRepeating("CoroutineProjectile",1,5);

	}
	
	void CoroutineProjectile()
	{
        //Starts the SimulateProjectile IEnumarator.
		StartCoroutine (SimulateProjectile());
	
	}

	IEnumerator SimulateProjectile()
	{
		//print ("IEnumerator ON");

		// Short delay added before Projectile is thrown.
		yield return new WaitForSeconds(delayTime);

		//Sets the Catapult Animation True
		_curveShootAnim = true;
		// Move projectile to the position of throwing object + add some offset if needed.
		projectile.position = nozzle.transform.position;
		
		// Calculate distance to target.
		float targetDistance = Vector3.Distance(projectile.position, target.position);
		
		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
		
		// Extract the X  Y componenent of the velocity.
		float VelocityX = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float VelocityY = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
		
		// Calculate flight time.
		float flightDuration = targetDistance / VelocityX;
		
		// Rotate projectile to face the target.
		projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);



		float elapseTime = 0;


		while (elapseTime < flightDuration)
		{

			//The Projectile will keep flying until it has reached his target location.
			projectile.Translate(0, (VelocityY - (gravity * elapseTime)) * Time.deltaTime, VelocityX * Time.deltaTime);
			
			elapseTime += Time.deltaTime;
			
			//print ("Projectile Is Flying!");
			
			yield return null;
		}

		//Sets the Catapult Animation false
		_curveShootAnim = false;

		//print ("Projectile Landed");	
	}


}