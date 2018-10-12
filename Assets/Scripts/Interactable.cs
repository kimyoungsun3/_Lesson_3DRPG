using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	public float radius = 3f;
	bool bFocus = false;
	Transform transPlayer;
	public Transform transformTarget;

	public void SetFocus(Transform _transPlayer){
		bFocus = true;
		transPlayer = _transPlayer;
	}

	public void RemoveFocus(){
		bFocus = false;
		transPlayer = null;
	}

	public virtual void Interact(){
		Debug.Log ("Interactable > Interact");
	}

	void Update(){
		if (bFocus) {
			float _distance = Vector3.Distance (transformTarget.position, transPlayer.position);
			if (_distance <= radius) {
				Debug.Log ("> Interact");
				Interact ();
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		if (transformTarget == null) {
			transformTarget = transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
