using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class AdrenalineBar : MonoBehaviour {
	
	[SerializeField] GameObject adrenalineImage;
	[SerializeField] private float adrenaline = 100f;
	[SerializeField] private float maxAdrenaline = 100f;
	[SerializeField] private float adrenalineRemoval = 0.5f;
	[SerializeField] private float adrenalineHitPoints = 10f;
	[SerializeField] private float smoothTime = 0.1f;
	[SerializeField] private float damageTaken = 10f;
	private float velocity;
	
	void Start() 
	{
		//makes the scale of the adrenaline bar.
		adrenalineImage.transform.localScale = new Vector3(adrenaline / 50, 0.2f, 0);
	}

	public float Adrenaline
	{
		//Using a getter and setter to access the EventHandeler. 
		get{return adrenaline;}
		set{

			//if the value is greater then the adrenaline and if the maxAdrenaline is greater then adrenaline then add adrenaline points.
			if (value  > adrenaline) {
					adrenaline += adrenalineHitPoints;

				if (maxAdrenaline < adrenaline) {
					adrenaline = maxAdrenaline;
				}

			//Else, lower the adrenaline points.
			} else
			{
				adrenaline -= adrenalineRemoval;
				if (maxAdrenaline < adrenaline) {
					adrenaline = maxAdrenaline;
				}
			}
		
		}
			
	}

	void Update()
	{
		//updates the adrenaline bar smooth when the points go up or down.
		float newX = Mathf.SmoothDamp (transform.localScale.x, adrenaline/50 - 0.02f, ref velocity, smoothTime);
		transform.localScale = new Vector3 (newX, transform.localScale.y, transform.localScale.z);
	}

	public void DamageTaken()
	{
		//Player Takes Damage from projectile
		adrenaline -= damageTaken;
	}
		
}