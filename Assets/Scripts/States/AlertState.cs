using UnityEngine;
using System.Collections;

public class AlertState : State {

    private bool alerted = false;

	public override void Act()
    {
        print("guys, the enemy is there");
        alerted = true;
    }

	public override void Reason()
    {
        if(alerted)
        {
            GetComponent<StateMachine>().SetState(StateID.Fleeing);
        }
	}

}