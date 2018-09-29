﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMotor : MonoBehaviour {
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();	
	}

	public void MoveToPoint(Vector3 _targetPos){
		agent.SetDestination (_targetPos);
	}

}
