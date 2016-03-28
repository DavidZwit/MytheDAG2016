using UnityEngine;
using System.Collections;

public class ChargeState : State
{
    private NavMeshAgent agent;

    private HealthBar hpBar;

    private bool atackMove;
    [SerializeField]
    private float originalSpeed;
    private float performaceTimer;
    private float distanceFromPlayer;



    public override void Enter()
    {
        base.Enter();
        hpBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
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
                //print(_player.gameObject);
                agent.SetDestination(_player.transform.position);
                distanceFromPlayer = calcDistanceSqrt(_player.transform.position, transform.position);
                if (distanceFromPlayer < 20)
                {
                    atackMove = true;
                    _anim.SetBool("attacking", atackMove);
                    StartCoroutine("attack");
                }
                else if (distanceFromPlayer < 200)
                {
                    agent.speed = originalSpeed + 2;
                    _anim.SetFloat("speed", 1.2f);
                    performaceTimer = Random.Range(0.15f, 0.2f);
                    //print(performaceTimer);
                }
                else
                {
                    agent.speed = originalSpeed;
                    _anim.SetFloat("speed", 1f);
                    performaceTimer = Random.Range(0.5f, 9f);
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
                doDamage();
                //_player.TakeDamage(damage);
            }

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }
        atackMove = false;
        _anim.SetBool("attacking", atackMove);
    }
    protected override void doDamage()
    {
        base.doDamage();
        hpBar.HealthDamageTaken();
        //print("god help me");
    }
    public override void Act()
    {
        base.Act();

    }

    public override void Reason()
    {
        
    }
}
