using UnityEngine;
using System.Collections;

public class DeathState : State
{

    public override void Enter()
    {
        base.Act();
        _anim.SetBool("alive", false);
    }
    

    public override void Act()
    {

        base.Act();

    }

    public override void Reason()
    {
        
    }
}
