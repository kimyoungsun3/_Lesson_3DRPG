using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMotor : MonoBehaviour {
	NavMeshAgent agent;
	Transform transTarget;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();	
	}

	//--------------------------------
	public void MoveToPoint(Vector3 _targetPos){
		agent.SetDestination (_targetPos);
	}

	//------------------------------------
	public void SetFocus(Interactable _scpInteractable){
		agent.stoppingDistance = _scpInteractable.radius * 0.8f;
		agent.updateRotation = false;
		transTarget = _scpInteractable.transform;
	}

	public void RemoveFocus(){
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
		transTarget = null;
	}

	Vector3 beforePosition;
	void FaceTarget(){
		//Vector3 _dir = transTarget.position - transform.position;
		Vector3 _dir = transform.position - beforePosition;
		beforePosition = transform.position;

		_dir.y = 0f;
		if (_dir != Vector3.zero) {
			Quaternion _dirQ = Quaternion.LookRotation (_dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, _dirQ, 5f * Time.deltaTime);
		}
	}

	void Update(){
		if (transTarget != null) {
			agent.SetDestination (transTarget.position);
			FaceTarget ();
		}
	}
}
