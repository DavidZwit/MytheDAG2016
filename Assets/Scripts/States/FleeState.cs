using UnityEngine;
using System.Collections;

public class FleeState : State {

    [SerializeField]
    private Transform saveZone;

    private bool inSaveZone;

    private float distanceFromSave;

    private Vector3 destination;

    private NavMeshAgent agent;

    public override void Enter()
    {
        inSaveZone = false;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(saveZone.position);
        agent.speed = 20;
        destination = agent.destination;
        StartCoroutine("toSaveZone");
    }

    IEnumerator toSaveZone()
    {
        while (true)
        {
            
            distanceFromSave = calcDistanceSqrt(destination, transform.position);
            if (distanceFromSave < 1)
            {
                inSaveZone = true;
                //print(distanceFromSave);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public override void Act()
    {

        base.Act();

    }
	
	public override void Reason(){
		if(inSaveZone)
        {
            StopCoroutine("toSaveZone");
            GetComponent<StateMachine>().SetState(StateID.Wandering);
        }
	}
}
