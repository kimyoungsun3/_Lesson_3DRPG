using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	public float radius = 3f;
	bool bFocus = false;
	Transform transPlayer;

	public void SetFocus(Transform _transPlayer){
		bFocus = true;
		transPlayer = _transPlayer;
	}

	public void RemoveFocus(){
		bFocus = false;
		transPlayer = null;
	}

	void Update(){
		if (bFocus) {
			float _distance = Vector3.Distance (transform.position, transPlayer.position);
			if (_distance <= radius) {
				Debug.Log ("> Interact");
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
