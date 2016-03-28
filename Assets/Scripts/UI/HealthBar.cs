using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

	[SerializeField] GameObject healthImage;
	[SerializeField] private float health = 100f;
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private float healthRemoval = 0.5f;
	[SerializeField] private float healthHitPoints = 10f;
	[SerializeField] private float smoothTime = 0.1f;
	[SerializeField] private float damageTaken = 10f;


    private State enemyDamg;//the enemy that gets spawned
    private float velocity;

	void Start() 
	{
		//makes the scale of the adrenaline bar.
		healthImage.transform.localScale = new Vector3(health / 50, 0.2f, 0);
	}

	/*
	public float Health
	{
		//Using a getter and setter to access the EventHandeler. 
		get{return health;}
		set{

			//if the value is greater then the adrenaline and if the maxAdrenaline is greater then adrenaline then add adrenaline points.
			if (value  > health) {
				health += healthHitPoints;

				if (maxHealth < health) {
					health = maxHealth;
				}

				//Else, lower the adrenaline points.
			} else
			{
				health -= healthRemoval;
				if (maxHealth < health) {
					health = maxHealth;
				}
			}

		}

	}
	*/

	void Update()
	{
		//updates the adrenaline bar smooth when the points go up or down.
		float newX = Mathf.SmoothDamp (transform.localScale.x, health/50 - 0.02f, ref velocity, smoothTime);
		transform.localScale = new Vector3 (newX, transform.localScale.y, transform.localScale.z);
        //enemyDamg._onDamage += HealthDamageTaken;
        if (health <= 0)
            SceneManager.LoadScene(0);
	}

	public void HealthDamageTaken()
	{
        //print("try me bitch");
		//Player Takes Damage from projectile
		health -= damageTaken;
	}

}