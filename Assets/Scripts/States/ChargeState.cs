using UnityEngine;
using System.Collections;

public class ChargeState : State
{
    private NavMeshAgent agent;

    private float originalSpeed;

    private float distanceFromPlayer;
    
    public override void Enter()
    {
        base.Enter();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("charge");
        originalSpeed = 10;
        print(agent.speed);
    }

    IEnumerator charge()
    {
        while (true)
        {
            agent.SetDestination(_player.transform.position);
            distanceFromPlayer = calcDistanceSqrt(_player.transform.position, transform.position);
            if (distanceFromPlayer < 3)
            {
                agent.speed = 0;
                attack();
            }
            else
            {
                print("speed = "+ originalSpeed);
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
