using UnityEngine;
using System.Collections;

public class WanderState : State {
    private float testCounter = 1f;

    [SerializeField]
	private float refreshRate = 0.5f;
	[SerializeField]
	private float walkDistance = 5f;
	private float walkDistancePow;
    private float distanceFromStart;
    private float distanceFromPlayer;
    [SerializeField]
	private float sightDistance = 5.5f;
    private float sightDistancePow;

    private bool coroutineGoing;
    private bool atPoint;
    private bool enemySpotted;

	[SerializeField]
	private Transform player;

    private Vector3 startPos;
    private Vector3 randomDirection;

    private NavMeshAgent agent;
	
	public override void Enter(){
        coroutineGoing = false;
        atPoint = true;
        enemySpotted = false;
        sightDistancePow = Mathf.Pow(sightDistance, 2);
        walkDistancePow = Mathf.Pow(walkDistance, 2);
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        agent.speed = 4;
        //print(startPos);
    }
    IEnumerator checkForPlayer()
    {
        while(true)
        {
            //float dist = Vector3.Distance(player.position, transform.position);
            //print(dist + "rekt");
            distanceFromPlayer = (player.position - transform.position).sqrMagnitude;
            if(distanceFromPlayer < sightDistancePow)
            {
                enemySpotted = true;
                //print("enemy");
            }
            //print(Mathf.Sqrt(distanceFromPlayer)+ "playerdist");
            //print(sightDistance+ "sightdist");
            yield return new WaitForSeconds(0.5f);
        }        
    }

    IEnumerator chooseTargetLocation()
    {
        while (true)
        {
            distanceFromStart = (startPos - transform.position).sqrMagnitude;
            if (distanceFromStart > walkDistancePow+1)
            {
                //print("go back");
                agent.SetDestination(startPos);
            }
            else
            {
                //print("wander more");
                randomDirection = Random.insideUnitSphere * (walkDistance);
                randomDirection += transform.position;
                agent.SetDestination(randomDirection);
                atPoint = false;
            }
            //print(walkDistancePow+ "walk");
            //print(distanceFromStart+ "dist");
            yield return new WaitForSeconds(refreshRate);
        }
    }

	public override void Act(){
        //print("woop");
        if (!coroutineGoing)
        {
            StartCoroutine("chooseTargetLocation");
            StartCoroutine("checkForPlayer");
            coroutineGoing = true;
        }
        //testCounter++;

    }

	public override void Reason(){
		//float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

		if(enemySpotted){
			// laten we switchen naar een nieuwe state
			GetComponent<StateMachine>().SetState( StateID.Alerting);
            StopCoroutine("chooseTargetLocation");
            StopCoroutine("checkForPlayer");
        }
	}
}
