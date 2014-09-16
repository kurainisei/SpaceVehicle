using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float distance;
	public float height;

	private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		cameraPosition = -target.forward*distance+target.position+transform.up*height;
		transform.position=cameraPosition;
		transform.LookAt(target);
	}



	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(cameraPosition,1);
	}
}
