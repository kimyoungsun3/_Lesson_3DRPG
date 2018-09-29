﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float pitch = 2f;
	public float zoomSpeed = 4f;
	public float zoomMin = 5f;
	public float zoomMax = 15;
	public float yawSpeed = 100f;
	private float currentZoom = 10f;
	private float currentYaw = 0f;

	void LateUpdate () {
		currentZoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp (currentZoom, zoomMin, zoomMax);
		currentYaw -= Input.GetAxis ("Horizontal") * yawSpeed * Time.deltaTime;

		transform.position = target.position - offset * currentZoom;
		transform.LookAt (target.position + Vector3.up * pitch);
		transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
