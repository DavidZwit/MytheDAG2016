using UnityEngine;
using System.Collections;

public class ChargeState : State
{
    private NavMeshAgent agent;

    private HealthBar hpBar;

    private Guard guard;

    private bool atackMove;
    private float originalSpeed;
    private float performaceTimer;
    private float distanceFromPlayer;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float dammage;
    float interpolation;



    public override void Enter()
    {
        base.Enter();
        guard = GetComponent<Guard>();
        hpBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        agent = GetComponent<NavMeshAgent>();
        speed += speed / 100 * _waveStats._percentSpeed;
        dammage += dammage / 100 * _waveStats._percentDamage;
        originalSpeed = speed;
        StartCoroutine("charge");
        atackMove = false;
        //print(agent.speed);
    }

    IEnumerator charge()
    {
        if (guard._alive)
        {
            while (true)
            {
                if (!atackMove)
                {
                    //print(_player.gameObject);
                    agent.SetDestination(_player.transform.position);
                    distanceFromPlayer = calcDistanceSqrt(_player.transform.position, transform.position);
                    if (distanceFromPlayer < 50)
                    {
                        atackMove = true;
                        _anim.SetBool("attacking", atackMove);
                        StartCoroutine("attack");
                    }
                    else if (distanceFromPlayer < 2000)
                    {
                        //print("test");
                        agent.speed = originalSpeed * 1.2f;
                        _anim.SetFloat("speed", 1.2f);
                        performaceTimer = Random.Range(0.2f, 0.25f);
                        //print(performaceTimer);
                    }
                    else
                    {
                        //print("test2");
                        agent.speed = originalSpeed;
                        _anim.SetFloat("speed", 1f);
                        performaceTimer = Random.Range(0.5f, 0.7f);
                    }
                }
                yield return new WaitForSeconds(performaceTimer);
            }
        }
    }

    IEnumerator attack()
    {
        if (guard._alive)
        {
            Vector3 originalPosition = transform.position;
            Vector3 dirToTarget = (_player.transform.position - transform.position).normalized;
            Vector3 attackPosition = _player.transform.position - dirToTarget * (2);

            //float attackSpeed = 0.8f;
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

                //percent += Time.deltaTime * attackSpeed;
                //interpolation = ((-Mathf.Pow(percent, 2) + percent) * 2) + 0.2f;
               //transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

                yield return null;
            }
            atackMove = false;
            _anim.SetBool("attacking", atackMove);
        }
    }
    protected override void doDamage()
    {
        if (guard._alive)
        {
            base.doDamage();
            hpBar.HealthDamageTaken(dammage);
            //print("god help me");
        }
    }
    public override void Act()
    {
        if (guard._alive)
        {
            base.Act();
            //print(interpolation);
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public override void Reason()
    {
        
    }
}
