using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mapManager : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float speed;
    private float distanceFromPoint;

    [SerializeField]
    private int lvlsDone;

    private bool toPoint;

    private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
            toPoint = true;
            
        }
        if (toPoint == true)
        {
            moveTo();
        }
    }

    void moveTo()
    {
        transform.LookAt(hit.point);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Debug.Log("This hit at " + hit.point);
        distanceFromPoint = (hit.point - transform.position).sqrMagnitude;
        if (distanceFromPoint < 1)
        {

            toPoint = false;
            for (int i = 0; i < waypoints.Length; i++)
            {
                //print(waypoints[i]);
                float distanceFromLvl = (waypoints[i].position - transform.position).sqrMagnitude;
                if (distanceFromLvl < 12)
                {
                    if (i < lvlsDone)
                    {
                        SceneManager.LoadScene(1);
                        print("next lvl plox");
                    }
                    else
                    {
                        print("GIT GOOD NUB");
                    }
                }
            }
        }
    }
}
