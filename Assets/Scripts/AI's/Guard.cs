using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
	NullStateID = 0,
	Wandering = 1,
	Alerting = 2,
	Fleeing = 3,
    Charge = 4,
    Patrol = 5
}

public class Guard : LivingEntity
{

    /** we declareren de statemachine */
    private StateMachine stateMachine;
    private Animator anim;
    [SerializeField]
    private bool patrol;
    [SerializeField]
    private bool charge;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();//gets the start from living entity
        //_startingHealth = _baseHp;
        //print(health + "hp");
        /** we halen een referentie op naar de state machine */
        stateMachine = GetComponent<StateMachine>();
        //anim.GetComponent<Animator>();
        /** we voegen de verschillende states toe aan de state machine */
		MakeStates();

        /** we geven de eerste state door (rondlopen) */
        if (patrol)
        {
            stateMachine.SetState(StateID.Patrol);
        }
        else if(charge)
        {
            stateMachine.SetState(StateID.Charge);
        }
        else
        {
            stateMachine.SetState(StateID.Wandering);
        }

    }

    protected override void death()
    {
        base.death();//gets the death from living entity
        //anim.SetBool("alive", false);
    }

    void MakeStates() {
		stateMachine.AddState( StateID.Alerting, GetComponent<AlertState>() );
		stateMachine.AddState( StateID.Wandering, GetComponent<WanderState>() );
		stateMachine.AddState( StateID.Fleeing, GetComponent<FleeState>() );
		stateMachine.AddState( StateID.Charge, GetComponent<ChargeState>() );
        stateMachine.AddState(StateID.Patrol, GetComponent<PatrolState>() );
    }

}