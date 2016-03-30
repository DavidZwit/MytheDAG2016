using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class RampageBar : MonoBehaviour {

	[SerializeField] GameObject rampageImage;
	[SerializeField] private float rampage = 100f;
	[SerializeField] private float maxRampage = 100f;
	[SerializeField] private float minRampage = 0f;
	[SerializeField] private float rampageRemoval = 0.5f;
	[SerializeField] private float rampageHitPoints = 10f;
	[SerializeField] private float smoothTime = 0.1f;
	[SerializeField] private float damageTaken = 10f;
	private float velocity;

	void Start() 
	{
		//makes the scale of the adrenaline bar.
		rampageImage.transform.localScale = new Vector3(rampage / 50, 0.2f, 0);
	}

	public float Rampage
	{
		//Using a getter and setter to access the EventHandeler. 
		get{return rampage;}
		set{

			//if the value is greater then the adrenaline and if the maxAdrenaline is greater then adrenaline then add adrenaline points.
			if (value  > rampage) 
			{
				rampage += rampageHitPoints;

				if (maxRampage < rampage) 
				{
					rampage = maxRampage;
				}

				//Else, lower the adrenaline points.
			} 
			else
			{
				rampage -= rampageRemoval;
				if (maxRampage < rampage) 
				{
					rampage = maxRampage;
				}
			}

		}

	}

	void Update()
	{
		//updates the adrenaline bar smooth when the points go up or down.
		float newX = Mathf.SmoothDamp (transform.localScale.x, rampage/50 - 0.02f, ref velocity, smoothTime);
		transform.localScale = new Vector3 (newX, transform.localScale.y, transform.localScale.z);
	}

	public void RampageDamageTaken()
	{
		//Player Takes Damage from projectile
		if (rampage - damageTaken >= 1) {
			
			rampage -= damageTaken;
		}
	}

}