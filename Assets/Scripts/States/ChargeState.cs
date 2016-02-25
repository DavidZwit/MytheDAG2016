using UnityEngine;
using System.Collections;

public class ChargeState : State
{
    private NavMeshAgent agent;

    private float originalSpeed;

    private float distanceFromPlayer;

    private Vector3 destination;

    public override void Enter()
    {
        base.Enter();
        destination = agent.destination;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("charge");
        originalSpeed = agent.speed;
    }

    IEnumerator charge()
    {
        while (true)
        {
            agent.SetDestination(_player.transform.position);
            distanceFromPlayer = calcDistanceSqrt(destination, transform.position);
            if (distanceFromPlayer < 6)
            {
                agent.speed = 0;
                attack();
            }
            else
            {
                agent.speed = originalSpeed;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void attack()
    {

    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        
    }
}
