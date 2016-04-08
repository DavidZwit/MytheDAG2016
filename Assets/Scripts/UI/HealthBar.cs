using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

	[SerializeField] GameObject healthImage;
	[SerializeField] private float health = 5f;
	[SerializeField] private float maxHealth = 100f;
	//[SerializeField] private float healthRemoval = 0.5f;
	//[SerializeField] private float healthHitPoints = 10f;
	[SerializeField] private float smoothTime = 0.1f;
    PlayerMovement player;
    SoundManager sound;
    OnHitFX hitFx;

    private float velocity;


	void Start() 
	{
        //makes the scale of the adrenaline bar.
        hitFx = GameObject.Find("HitFXImage").GetComponent<OnHitFX>();
		healthImage.transform.localScale = new Vector3(health / 72, 0.2f, 0);
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
        player = GameObject.Find("Player(Goliath)").GetComponent<PlayerMovement>();
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
		float newX = Mathf.SmoothDamp (transform.localScale.x, health/72 - 0.02f, ref velocity, smoothTime);
		transform.localScale = new Vector3 (newX, transform.localScale.y, transform.localScale.z);
		if (health <= 0f) 
		{
            player._anim.SetTrigger("Death");
            player.enabled = false;
            sound.PlayAudio(16,Death);
        }
	}

	public void HealthDamageTaken(float damageTaken)
	{
		//Player Takes Damage from projectile
		health -= damageTaken;
        hitFx.TurnOn(0.08f);      
	}

    void Death()
    {
        HideMouse.UnlockCursor();
        SceneManager.LoadScene(0);
    }
}