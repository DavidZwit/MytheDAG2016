using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventHandeler : MonoBehaviour {
	
    RandomShake screenShake;

    public delegate void ReachedObjective();
    public static event ReachedObjective _ObjectiveReached;

	//AdrenalineBar adrenalineBar;
	RampageBar rampageBar;
	HealthBar healthBar;
    AddScore scoreAdd;
    [SerializeField] [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
		//adrenalineBar = GameObject.Find("AdrenalineBar").GetComponent<AdrenalineBar> (); 
		rampageBar = GameObject.Find("RampageBar").GetComponent<RampageBar> (); 
		healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar> (); 
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
    }

    void Start()
    {
		//InvokeRepeating ("AdrenalineBarDecreasing" ,0.1f ,0.1f);
		InvokeRepeating ("RampageAndHealthBarDecreasing" ,0.1f ,0.1f);
        brokenObjectsNeededLeft = (breakableObjects / 100) * Mathf.Abs(perCentWonCodition - 100);
    }

    public float BreakableObjects
    {
        get { return breakableObjects; }
        set { breakableObjects = value;
            if (breakableObjects < brokenObjectsNeededLeft) _ObjectiveReached();
        }
    }

	public void SomethingBroke(GameObject coll)
    {
        scoreAdd.IncreaseScore(100);
        screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();

		//Adds Adrenaline
		//adrenalineBar.Adrenaline++;

		rampageBar.Rampage++;

        if (coll.gameObject.name == "kasteel_model")
			SceneManager.LoadScene(0);
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
			SoundManager.PlayAudio (1,1);
        }
        else if (coll.gameObject.tag == "Player")
        {
			//Decreases Adrenaline when hit.
			//adrenalineBar.DamageTaken ();

			rampageBar.RampageDamageTaken ();

			healthBar.HealthDamageTaken ();

			//For the effect of the hit
        }
    }

	/*
	void AdrenalineBarDecreasing()
	{
		//Decreases the adrenalineBar every few seconds.
		adrenalineBar.Adrenaline -= 5f;

		//If the adrenalineBar hits zero, load the following Scene.
		if(adrenalineBar.Adrenaline <= 0f)
		{
			SceneManager.LoadScene ("StartMenu");
		}

	}
	*/

	void RampageAndHealthBarDecreasing()
	{
		//Decreases the adrenalineBar every few seconds.
		rampageBar.Rampage -= 5f;

		//If the adrenalineBar hits zero, load the following Scene.
		if(rampageBar.Rampage <= 0f)
		{
			
			//SceneManager.LoadScene ("StartMenu");
		}
		/*
		if (healthBar.HealthDamageTaken <= 0f) 
		{
			SceneManager.LoadScene ("StartMenu");
		}
		*/
	}

		
}
