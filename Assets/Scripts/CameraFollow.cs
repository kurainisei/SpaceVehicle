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
		if (target){
			cameraPosition = -target.forward*distance+target.position;
			transform.position=new Vector3 (cameraPosition.x, target.position.y+height , cameraPosition.z);
			transform.LookAt(target);
		}

	}



	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(cameraPosition,1);
	}
}
