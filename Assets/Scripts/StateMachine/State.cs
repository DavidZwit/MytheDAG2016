using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {

    [HideInInspector]
    public event System.Action _onDamage;
    [HideInInspector]
    protected GameObject _player;
    [HideInInspector]
    public bool _alertedByOther;
    [HideInInspector]
    protected bool _targetAlive;
    [HideInInspector]
    protected Animator _anim;


    public virtual void Enter ()
	{
        _player = GameObject.FindGameObjectWithTag("Player");
        _alertedByOther = false;
        if (_player != null)
            _targetAlive = true;
        _anim = GetComponent<Animator>();
    }

	public virtual void Leave ()
	{
	}

    public virtual void Act()
    {
        if (_player == null)
            _targetAlive = false;
        //print("act??");
        if (_alertedByOther)
        {
            print("letsTest");
            GetComponent<StateMachine>().SetState(StateID.Alerting);
        }
    }

    virtual protected void doDamage()//when would this be used >_>
    {
        if (_onDamage != null)
            _onDamage();
    }

    public abstract void Reason ();

    public float calcDistanceSqrt(Vector3 otherTransform, Vector3 ownTransform)
    {
        float distance = (otherTransform - ownTransform).sqrMagnitude;
        //print("does dis");
        return distance;
    }
}

