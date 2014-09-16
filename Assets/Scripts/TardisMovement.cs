﻿using UnityEngine;
using System.Collections;

public class TardisMovement : MonoBehaviour {
	public float hardAcceleration;
	public float softAcceleration;
	public float gravityAcceleration;
	public float rotationSpeed;

	private Vector3 _gravity;
	private Vector3 _thrust;
	private Vector3 _acceleration;
	private Vector3 _velocity;

	private float _rotationX=0;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//inclination on X axis to move forward/backwards 
		//this is bullshit. Just multiply vaxis by 35 and THEN slerp current rotation to this one by Time.deltaTime. 
		_rotationX = Mathf.Lerp (0, 35, Mathf.Abs(Input.GetAxis("Vertical"))) * Mathf.Sign(Input.GetAxis("Vertical"));

		transform.rotation = Quaternion.AngleAxis(_rotationX, transform.right);

		//rotation on Y axis to turn
		//transform.localRotation = transform.localRotation* Quaternion.Euler( Vector3.up * rotationSpeed);


		//gravity and thrust behavior
		_gravity = Vector3.down*gravityAcceleration;

		if (Input.GetButton("ThrustLow")) {
			_thrust = transform.up*softAcceleration;
		}
		else if (Input.GetButton("ThrustHigh")) {
			_thrust = transform.up*hardAcceleration;
		}
		else
		{
			_thrust = Vector3.zero;
		}
		_acceleration = _gravity+_thrust;
		_velocity += _acceleration;

		//clamp velocity magnitude to avoid too much speed
		if (_velocity.y > 0 && _velocity.magnitude > 10)
		{
			_velocity = Vector3.ClampMagnitude(_velocity,10.0f);
		}

		transform.Translate (_velocity*Time.deltaTime);

		_acceleration=Vector3.zero;
	}
}
