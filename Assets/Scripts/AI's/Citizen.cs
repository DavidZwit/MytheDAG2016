using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CitizenStateID
{
    NullStateID = 0,
}
public class Citizen : LivingEntity {

    /** we declareren de statemachine */
    private StateMachine stateMachine;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();//gets the start from living entity
        /** we halen een referentie op naar de state machine */
        stateMachine = GetComponent<StateMachine>();

        /** we voegen de verschillende states toe aan de state machine */
        MakeStates();

        /** we geven de eerste state door (rondlopen) */
        stateMachine.SetState(StateID.Wandering);
    }
    protected override void death()
    {
        base.death();//gets the death from living entity
    }
    void MakeStates()
    {
        stateMachine.AddState(StateID.Alerting, GetComponent<AlertState>());
        stateMachine.AddState(StateID.Wandering, GetComponent<WanderState>());
        stateMachine.AddState(StateID.Fleeing, GetComponent<FleeState>());
    }
}
