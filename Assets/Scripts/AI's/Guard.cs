using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
	NullStateID = 0,
	Wandering = 1,
	Alerting = 2,
	Fleeing = 3
}

public class Guard : MonoBehaviour {

	/** we declareren de statemachine */
	private StateMachine stateMachine;

	// Use this for initialization
	void Start () {
		/** we halen een referentie op naar de state machine */
		stateMachine = GetComponent<StateMachine>();

		/** we voegen de verschillende states toe aan de state machine */
		MakeStates();

		/** we geven de eerste state door (rondlopen) */
		stateMachine.SetState( StateID.Wandering );
	}
	
	void MakeStates() {
		stateMachine.AddState( StateID.Alerting, GetComponent<AlertState>() );
		stateMachine.AddState( StateID.Wandering, GetComponent<WanderState>() );
		stateMachine.AddState( StateID.Fleeing, GetComponent<FleeState>() );
	}

}