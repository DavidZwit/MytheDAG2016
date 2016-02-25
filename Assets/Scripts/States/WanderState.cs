using UnityEngine;
using System.Collections;

public class WanderState : State {

	[SerializeField]
	private float walkDistance = 5f;
	private float walkDistancePow;
    private float distanceFromStart;
    private float distanceFromPlayer;
    [SerializeField]
	private float sightDistance = 5.5f;
    private float sightDistancePow;
    
    private bool atPoint;
    private bool enemySpotted;
    
    private Vector3 startPos;
    private Vector3 randomDirection;

    private NavMeshAgent agent;
	
	public override void Enter()
    {
        base.Enter();
        atPoint = true;
        enemySpotted = false;
        sightDistancePow = Mathf.Pow(sightDistance, 2);
        walkDistancePow = Mathf.Pow(walkDistance, 2);
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        agent.speed = 4; StartCoroutine("chooseTargetLocation");
        StartCoroutine("checkForPlayer");
        //print(startPos);
    }
    IEnumerator checkForPlayer()
    {
        while(true)
        {
            distanceFromPlayer = calcDistanceSqrt(_player.transform.position, transform.position);
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
            distanceFromStart = calcDistanceSqrt(startPos, transform.position);
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
            yield return new WaitForSeconds(Random.Range(3,5));
        }
    }

	public override void Act(){
        

    }

	public override void Reason(){
		if(enemySpotted){
            StopCoroutine("chooseTargetLocation");
            StopCoroutine("checkForPlayer");
            GetComponent<StateMachine>().SetState(StateID.Alerting);
        }
	}
}
