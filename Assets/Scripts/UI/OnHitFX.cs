using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnHitFX : MonoBehaviour {

	[SerializeField] private Image fxImage;

	// Use this for initialization
	void Start()
	{
		fxImage = GetComponent<Image> ();

		Color fxAlpha = fxImage.color;
		fxAlpha.a = 0;
		fxImage.color = fxAlpha;

	}

	public void TurnOn(float flashbang)
	{
		Color fxAlpha = fxImage.color;
		fxAlpha.a = 0.5f;
		fxImage.color = fxAlpha;
		
		Invoke ("TurnOff", flashbang);
	}

	void TurnOff()
	{

		Color fxAlpha = fxImage.color;
		fxAlpha.a = 0f;
		fxImage.color = fxAlpha;
	}


}
