using UnityEngine;
using System.Collections;

public class TardisMovement : MonoBehaviour {
	public float hardAcceleration;
	public float softAcceleration;
	public float gravityAcceleration;
	public float rotationSpeed;
	public float landingSpeedLimit;


	private Vector3 _gravity;
	private Vector3 _thrust;
	private Vector3 _acceleration;
	private Vector3 _velocity;
	
	private float _rotationX=0;
	private float _rotationY=0;
	private LandingSensor _landSensor;
	private bool _hasLanded = false;
	private AutoRotate _tardisContinueRotation;

	// Use this for initialization
	void Start () {
		_landSensor = GetComponent<LandingSensor>();
		_tardisContinueRotation = GetComponentInChildren<AutoRotate>();
		_tardisContinueRotation.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if (!_hasLanded) {
			//inclination on X axis to move forward/backwards 
			_rotationX = Mathf.Lerp (0, 35, Mathf.Abs(Input.GetAxis("Vertical"))) * Mathf.Sign(Input.GetAxis("Vertical")*Time.deltaTime);
			_rotationY += Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime;

			Quaternion spinBy = Quaternion.AngleAxis(_rotationX, transform.right);
			transform.rotation = spinBy*Quaternion.AngleAxis(_rotationY, Vector3.up);

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
			_acceleration=Vector3.zero;

			//clamp velocity magnitude to avoid too much speed
			if (_velocity.y > 0 && _velocity.magnitude > 10)
			{
				_velocity = Vector3.ClampMagnitude(_velocity,10.0f);
			}

			//check if landed
			if (transform.rotation.x==0&&_velocity.y>landingSpeedLimit&&_velocity.y<=0){

				Vector3 hitpoint;

				if (_landSensor.CheckLandingPoint (out hitpoint, 0.2f)){
					transform.position=hitpoint;
					_hasLanded=true;
					_tardisContinueRotation.enabled=false;
					Debug.Log("landed!");
				}
				else {
					transform.position +=  _velocity*Time.deltaTime;
				}
			}
			else {
				transform.position +=  _velocity*Time.deltaTime;
			}

		}//if the tardis has not landed
	}
}
