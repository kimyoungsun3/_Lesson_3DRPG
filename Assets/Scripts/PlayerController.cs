using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float distance = 100f;
	public LayerMask groundMask;

	PlayerMotor motor;
	Camera cam;

	void Start () {
		cam = Camera.main;	
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		//mouse click and character move.
		if (Input.GetMouseButtonDown (0)) {
			Ray _ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit _hit;

			if(Physics.Raycast(_ray, out _hit, distance, groundMask)){
				Debug.Log("hit point " + _hit.collider.name + " " + _hit.point);
				motor.MoveToPoint (_hit.point);
			}
		}

		//mouse right click and item eat
		if (Input.GetMouseButtonDown (1)) {
			Ray _ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit _hit;

			if(Physics.Raycast(_ray, out _hit, distance)){
				//Check if we hit an interactable.
				//if we did set it as our forus.
			}
		}
	}
}
