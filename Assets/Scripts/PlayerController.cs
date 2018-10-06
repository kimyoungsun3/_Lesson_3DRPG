using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float distance = 100f;
	public LayerMask groundMask;

	PlayerMotor motor;
	Camera cam;
	public Interactable scpFocus;

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

				RemoveFocus ();
			}
		}

		//mouse right click and item eat
		if (Input.GetMouseButtonDown (1)) {
			Ray _ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit _hit;

			if(Physics.Raycast(_ray, out _hit, distance)){
				//Check if we hit an interactable.
				Interactable _scpInteractable = _hit.collider.GetComponent<Interactable>();
				if(_scpInteractable != null)
				{
					//if we did set it as our forus.
					SetFocus(_scpInteractable);
				}
			}
		}
	}

	void SetFocus(Interactable _scpInteractable){
		scpFocus = _scpInteractable;
		motor.SetFocus (_scpInteractable);

	}

	void RemoveFocus(){
		scpFocus = null;
		motor.RemoveFocus ();

	}
}
