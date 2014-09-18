using UnityEngine;
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
	private float _rotationY=0;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//inclination on X axis to move forward/backwards 
		_rotationX = Mathf.Lerp (0, 35, Mathf.Abs(Input.GetAxis("Vertical"))) * Mathf.Sign(Input.GetAxis("Vertical")*Time.deltaTime);
		_rotationY += Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime;

		Quaternion spinBy = Quaternion.AngleAxis(_rotationY, Vector3.up);
		transform.rotation = spinBy*Quaternion.AngleAxis(_rotationX, transform.right);

		//rotation on Y axis to turn
		//transform.rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime *Input.GetAxis("Horizontal"), Vector3.up)*transform.rotation;


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

		transform.position +=  _velocity*Time.deltaTime;

		_acceleration=Vector3.zero;
	}
}
