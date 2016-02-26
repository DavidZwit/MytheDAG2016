using UnityEngine;
using System.Collections;

public class EventHandeler : MonoBehaviour {
    
    RandomShake screenShake;

    private Transform player;
    public delegate void ReachedObjective();
    public static event ReachedObjective _ObjectiveReached;

    AddScore scoreAdd;
    [SerializeField] [Range(0, 100)]
    int perCentWonCodition;
    float brokenObjectsNeededLeft, breakableObjects = 0;

    void Awake()
    {
        scoreAdd = GetComponent<AddScore>();
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
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
        if (coll.gameObject.name == "kasteel_model")
            Application.LoadLevel(0);
    }

    public void BulletHitSomething(Collision coll)
    {
        if (coll.gameObject.tag == "Breakable")
        {
            coll.gameObject.GetComponent<ChangeToBrokenModelOnCollisionWith>().Break();
        }
        else if (coll.gameObject.tag == "Player")
        {
            scoreAdd.DecreaseScore(100);
            //remove adrealine
        }
    }

    public void PickupProjectile(GameObject coll)
    {
        coll.gameObject.transform.parent = player;
        coll.gameObject.transform.position = new Vector3(player.position.x, player.position.y + 3, player.position.z);
    }
}
