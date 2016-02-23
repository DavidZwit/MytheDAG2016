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
    }

    IEnumerator toSaveZone()
    {
        while (true)
        {
            distanceFromSave = (destination - transform.position).sqrMagnitude;
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
        StartCoroutine("toSaveZone");
    }
	
	public override void Reason(){
		if(inSaveZone)
        {
            StopCoroutine("toSaveZone");
            GetComponent<StateMachine>().SetState(StateID.Wandering);
        }
	}
}
