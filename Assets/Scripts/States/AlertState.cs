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
        if (alerted)
        {
            if (this.tag == "citizen")
            {
                GetComponent<StateMachine>().SetState(StateID.Fleeing);
            }
            if(this.tag == "soldier")
            {
                GetComponent<StateMachine>().SetState(StateID.Charge);
            }
        }
	}
}