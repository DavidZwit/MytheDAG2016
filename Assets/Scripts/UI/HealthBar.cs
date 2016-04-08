using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

	[SerializeField] GameObject healthImage;
	[SerializeField] private float health = 5f;
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private float smoothTime = 0.1f;
	[SerializeField] private float damageTaken = 10f;
	WinAndLoseCondition lose;
	OnHitFX hitFX;

	private float velocity;

	void Start() 
	{
		lose = GameObject.Find ("WinAndLoseCondition").GetComponent<WinAndLoseCondition> ();
		hitFX = GameObject.Find ("HitFXImage").GetComponent<OnHitFX> ();
		//makes the scale of the adrenaline bar.
		healthImage.transform.localScale = new Vector3(health /72, 0.2f, 0);
	}

	void Update()
	{
		//updates the adrenaline bar smooth when the points go up or down.
		float newX = Mathf.SmoothDamp (transform.localScale.x, health/72 - 0.02f, ref velocity, smoothTime);
		transform.localScale = new Vector3 (newX, transform.localScale.y, transform.localScale.z);
		if (health <= 0f) 
		{
			lose.Lose ();
		}
	}

	public void HealthDamageTaken()
	{
		//Player Takes Damage from projectile
		health -= damageTaken;

		hitFX.TurnOn (1f);

	}

}