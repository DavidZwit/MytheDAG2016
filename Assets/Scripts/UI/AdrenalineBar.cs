using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class AdrenalineBar : MonoBehaviour {
	
	[SerializeField] GameObject adrenalineImage;
	[SerializeField] private float adrenaline = 100f;
	[SerializeField] private float maxAdrenaline = 100f;
	[SerializeField] private float adrenalineRemoval = 10f;
	[SerializeField] private float adrenalineHitPoints = 10f;
	
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
				if (maxAdrenaline > adrenaline) {

					adrenaline += adrenalineHitPoints;
					//print (adrenaline);

				}
			//Else, lower the adrenaline points.
			} else
			{
				adrenaline -= adrenalineRemoval;
				//print (adrenaline);

			}

			//updates the adrenaline bar when the points go up or down.
			adrenalineImage.transform.localScale = new Vector3(adrenaline / 50, 0.2f, 0);
			
		}
	}



}