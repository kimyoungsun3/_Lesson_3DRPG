using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour {
	NavMeshAgent agent;
	Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float _speed = agent.velocity.magnitude / agent.speed;
		animator.SetFloat ("SpeedPercent", _speed, 0.1f, Time.deltaTime);
	}
}
