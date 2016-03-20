using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {
    [HideInInspector]
    protected GameObject _player;
    [HideInInspector]
    public bool _alertedByOther;
    [HideInInspector]
    protected bool _targetAlive;


    public virtual void Enter ()
	{
        _player = GameObject.FindGameObjectWithTag("Player");
        _alertedByOther = false;
        if (_player != null)
            _targetAlive = true;
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

	public abstract void Reason ();

    public float calcDistanceSqrt(Vector3 otherTransform, Vector3 ownTransform)
    {
        float distance = (otherTransform - ownTransform).sqrMagnitude;
        //print("does dis");
        return distance;
    }
}

