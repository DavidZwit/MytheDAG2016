using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventHandeler : MonoBehaviour
{
    SpawnExplosiveBarrel spawnExplosiveBarrel;
    RandomShake screenShake;

    public delegate void ReachedObjective();
    public static event ReachedObjective _ObjectiveReached;

    //AdrenalineBar adrenalineBar;
    RampageBar rampageBar;
    HealthBar healthBar;
    AddScore scoreAdd;
    SoundManager sound;
    [SerializeField]
    [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
        //adrenalineBar = GameObject.Find("AdrenalineBar").GetComponent<AdrenalineBar> (); 
        rampageBar = GameObject.Find("RampageBar").GetComponent<RampageBar>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        scoreAdd = GetComponent<AddScore>();
        spawnExplosiveBarrel = GetComponent<SpawnExplosiveBarrel>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
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
        scoreAdd.IncreaseScore(100);
        //screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        spawnExplosiveBarrel.AddSpawnChance(coll.gameObject);
        //Adds Adrenaline
        //adrenalineBar.Adrenaline++;

        rampageBar.Rampage++;

        if (coll.gameObject.name == "kasteel_model")
        {
            SceneManager.LoadScene(0);
            sound.PlayAudio(20);
        }
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        }
        else if (coll.gameObject.tag == "Wall")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
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