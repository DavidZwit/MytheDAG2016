using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
<<<<<<< HEAD

public class EventHandeler : MonoBehaviour
{
    Fade fade;
=======

public class EventHandeler : MonoBehaviour
{

>>>>>>> master
    RandomShake screenShake;

    public delegate void ReachedObjective();
    public delegate void BuildingBroke(GameObject building);
    public static event BuildingBroke _buildingBroke;
    public static event ReachedObjective _ObjectiveReached;

<<<<<<< HEAD
    AdrenalineBar adrenalineBar;
=======
    //AdrenalineBar adrenalineBar;
    RampageBar rampageBar;
    HealthBar healthBar;
>>>>>>> master
    AddScore scoreAdd;
    [SerializeField]
    [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
<<<<<<< HEAD
        adrenalineBar = GameObject.Find("Image").GetComponent<AdrenalineBar>();
=======
        //adrenalineBar = GameObject.Find("AdrenalineBar").GetComponent<AdrenalineBar> (); 
        rampageBar = GameObject.Find("RampageBar").GetComponent<RampageBar>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
>>>>>>> master
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
    }

    void Start()
    {
<<<<<<< HEAD
        InvokeRepeating("AdrenalineBarDecreasing", 1, 2);
=======
        //InvokeRepeating ("AdrenalineBarDecreasing" ,0.1f ,0.1f);
        StartCoroutine("RampageBarDecreasing");
>>>>>>> master
        brokenObjectsNeededLeft = (breakableObjects / 100) * Mathf.Abs(perCentWonCodition - 100);
    }

    public float BreakableObjects
    {
        get { return breakableObjects; }
        set
        {
            breakableObjects = value;
            if (breakableObjects < brokenObjectsNeededLeft) _ObjectiveReached();
        }
    }

    public void SomethingBroke(GameObject coll)
    {
<<<<<<< HEAD
        if (_buildingBroke != null)
            _buildingBroke(coll);

        scoreAdd.IncreaseScore(100);
        screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        
        //Adds Adrenaline
        adrenalineBar.Adrenaline++;
=======
        //scoreAdd.IncreaseScore(100);
        //screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();

        //Adds Adrenaline
        //adrenalineBar.Adrenaline++;

        rampageBar.Rampage++;
>>>>>>> master

        if (coll.gameObject.name == "kasteel_model")
            SceneManager.LoadScene(0);
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
<<<<<<< HEAD

        else if (coll.gameObject.tag == "Player")
        {
            scoreAdd.DecreaseScore(100);
            //Decreases Adrenaline when hit.
            adrenalineBar.Adrenaline -= 5f;
        }
    }

    public void QuestStatus()
    {

    }

    void AdrenalineBarDecreasing()
    {
        //Decreases the adrenalineBar every few seconds.
        adrenalineBar.Adrenaline -= 5f;

        if (adrenalineBar.Adrenaline <= 0f)
        {
            fade.StartFade(2, LoadLevel);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(2);
=======
           
        }
        else if (coll.gameObject.tag == "Player")
        {
            //Decreases Adrenaline when hit.
            //adrenalineBar.DamageTaken ();

            //rampageBar.RampageDamageTaken ();
            //print(coll.gameObject.name);
            healthBar.HealthDamageTaken();
            //print("print me");

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

    IEnumerator RampageBarDecreasing()
    {
        while (true)
        {
            if (rampageBar.Rampage >= 1f)
            {
                rampageBar.Rampage--;
            }
            //print("removing rampage");
            //Decreases the adrenalineBar every few seconds.
            yield return new WaitForSeconds(0.1f);

        }

>>>>>>> master
    }
}