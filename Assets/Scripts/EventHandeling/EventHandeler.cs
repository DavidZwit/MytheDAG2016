using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventHandeler : MonoBehaviour
{
    Fade fade;
    RandomShake screenShake;

    public delegate void ReachedObjective();
    public delegate void BuildingBroke(GameObject building);
    public static event BuildingBroke _buildingBroke;
    public static event ReachedObjective _ObjectiveReached;

    AdrenalineBar adrenalineBar;
    AddScore scoreAdd;
    [SerializeField]
    [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
        adrenalineBar = GameObject.Find("Image").GetComponent<AdrenalineBar>();
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
    }

    void Start()
    {
        InvokeRepeating("AdrenalineBarDecreasing", 1, 2);
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
        if (_buildingBroke != null)
            _buildingBroke(coll);

        scoreAdd.IncreaseScore(100);
        screenShake.Shake(new Vector2(0.5f, 0.3f), 0.8f, 0.01f);
        coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        
        //Adds Adrenaline
        adrenalineBar.Adrenaline++;

        if (coll.gameObject.name == "kasteel_model")
            SceneManager.LoadScene(0);
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();

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
    }
}