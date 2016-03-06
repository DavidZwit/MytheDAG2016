using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {
    [HideInInspector]
    public GameObject _player;
    public bool _alertedByOther;
    

    public virtual void Enter ()
	{
        _player = GameObject.FindGameObjectWithTag("Player");
	}

	public virtual void Leave ()
	{
	} 

	public virtual void Act ()
    {

    }

	public abstract void Reason ();

    public float calcDistanceSqrt(Vector3 otherTransform, Vector3 ownTransform)
    {
        float distance = (otherTransform - ownTransform).sqrMagnitude;
        //print("does dis");
        return distance;
    }
}

