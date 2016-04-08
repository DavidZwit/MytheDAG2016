using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventHandeler : MonoBehaviour
{
    RandomShake screenShake;

    public delegate void ReachedObjective();
    public static event ReachedObjective _ObjectiveReached;

	WinAndLoseCondition win;
    RampageBar rampageBar;
    HealthBar healthBar;
    AddScore scoreAdd;
    [SerializeField]
    [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
		
		win = GameObject.Find("WinAndLoseCondition").GetComponent<WinAndLoseCondition> (); 
        rampageBar = GameObject.Find("RampageBar").GetComponent<RampageBar>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
    }

    void Start()
    {
        //InvokeRepeating ("AdrenalineBarDecreasing" ,0.1f ,0.1f);
        StartCoroutine("RampageBarDecreasing");
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
        //scoreAdd.IncreaseScore(100);
        //screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();

        rampageBar.Rampage++;

        if (coll.gameObject.name == "kasteel_model")
		{
			win.Win ();
            //SceneManager.LoadScene(0);
		}

    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
           
        }
        else if (coll.gameObject.tag == "Player")
		{
            //rampageBar.RampageDamageTaken ();
            //print(coll.gameObject.name);
            healthBar.HealthDamageTaken();
            //print("print me");

            //For the effect of the hit
        }
    }

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

    }
}