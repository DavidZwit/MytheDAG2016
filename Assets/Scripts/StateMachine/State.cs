﻿using UnityEngine;
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
    [HideInInspector]
    protected GameObject _findSpawner;//finds spawner object
    [HideInInspector]
    protected SpawnSystem _waveStats;//imports spawnsystem


    public virtual void Enter ()
	{
        _findSpawner = GameObject.Find("unitSpawner");
        _waveStats = _findSpawner.GetComponent<SpawnSystem>();
        _player = GameObject.FindGameObjectWithTag("playerGoliath");
        _alertedByOther = false;
        if (_player != null)
            _targetAlive = true;
        _anim = GetComponent<Animator>();
        //print(_player.transform.position);
    }

	public virtual void Leave ()
	{
	}

    public virtual void Act()
    {
        if (_player == null)
        {
            _targetAlive = false;
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        //print("act??");
        if (_alertedByOther)
        {
            print("letsTest");
            GetComponent<StateMachine>().SetState(StateID.Alerting);
        }
    }

    virtual protected void doDamage()//when would this be used >_>
    {
        /*if (_onDamage != null)
            _onDamage();*/
    }

    public abstract void Reason ();

    public float calcDistanceSqrt(Vector3 otherTransform, Vector3 ownTransform)
    {
        float distance = (otherTransform - ownTransform).sqrMagnitude;
        //print("does dis");
        return distance;
    }
}

