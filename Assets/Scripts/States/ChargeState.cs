using UnityEngine;
using System.Collections;

public class ChargeState : State
{
    private NavMeshAgent agent;

    private bool atackMove;
    [SerializeField]
    private float originalSpeed;
    private float performaceTimer;
    private float distanceFromPlayer;
    
    public override void Enter()
    {
        base.Enter();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("charge");
        originalSpeed = 10;
        atackMove = false;
        //print(agent.speed);
    }

    IEnumerator charge()
    {
        while (true)
        {
            if (!atackMove)
            {
                agent.SetDestination(_player.transform.position);
                distanceFromPlayer = calcDistanceSqrt(_player.transform.position, transform.position);
                if (distanceFromPlayer < 20)
                {
                    atackMove = true;
                    StartCoroutine("attack");
                }
                else if (distanceFromPlayer < 200)
                {
                    agent.speed = originalSpeed + 2;
                    performaceTimer = 0.2f;
                }
                else
                {
                    agent.speed = originalSpeed;
                    performaceTimer = 1;
                }
            }
            yield return new WaitForSeconds(performaceTimer);
        }
    }

    IEnumerator attack()
    {
        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (_player.transform.position - transform.position).normalized;
        Vector3 attackPosition = _player.transform.position - dirToTarget * (1);

        float attackSpeed = 3;
        float percent = 0;

        bool hasAppliedDamage = false;

        while (percent <= 1)
        {

            if (percent >= .5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                //_player.TakeDamage(damage);
            }

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }
        atackMove = false;
    }

    /*IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (_targetAlive)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (_player.transform.position - transform.position).normalized;
                Vector3 targetPosition = _player.transform.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
                agent.SetDestination(_player.transform.position);

            }
            yield return new WaitForSeconds(refreshRate);
        }
    }*/

    public override void Act()
    {
        base.Act();

    }

    public override void Reason()
    {
        
    }
}
