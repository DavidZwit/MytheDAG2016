using UnityEngine;
using System.Collections;

public class PatrolState : State {

    [SerializeField]
    private Transform[] waypoints;

    private NavMeshAgent agent;

    private Vector3 destination;

    private bool enemySpotted;

    private int pointCounter;

    private float distanceFromPoint;
    private float distanceFromPlayer;
    [SerializeField]
    private float sightDistance = 5.5f;
    private float sightDistancePow;

    public override void Enter()
    {
        base.Enter();
        enemySpotted = false;
        sightDistancePow = Mathf.Pow(sightDistance, 2);
        pointCounter = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[pointCounter].position);
        destination = agent.destination;
        agent.speed = 7;
        StartCoroutine("toPoint");
        StartCoroutine("seeEnemy");
    }

    IEnumerator toPoint()
    {
        while (true)
        {
            distanceFromPoint = (destination - transform.position).sqrMagnitude;
            if (distanceFromPoint < 6)
            {
                pointCounter++;
                if(pointCounter >= waypoints.Length)
                {
                    pointCounter = 0;
                }
                agent.SetDestination(waypoints[pointCounter].position);
                destination = agent.destination;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator seeEnemy()
    {
        while (true)
        {
            //print("ehbos");
            distanceFromPlayer = (_player.transform.position - transform.position).sqrMagnitude;
            if (distanceFromPlayer < sightDistancePow)
            {
                enemySpotted = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public override void Act()
    {

    }

    public override void Reason()
    {
        if(enemySpotted)
        {
            print("enemy!");
            StopCoroutine("toPoint");
            StopCoroutine("seeEnemy");
            GetComponent<StateMachine>().SetState(StateID.Alerting);
        }
    }
}
