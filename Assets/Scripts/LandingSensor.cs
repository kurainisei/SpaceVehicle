using UnityEngine;
using System.Collections;

public class LandingSensor : MonoBehaviour {
	public LayerMask platformLayer;
	// Use this for initialization
	void Start () {
	
	}

	public bool CheckLandingPoint (out Vector3 hitpoint, float distanceLimit) {

			Ray ray = new Ray (transform.position, Vector3.down);
			RaycastHit hit;
			
			
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, platformLayer) && hit.distance < distanceLimit) {
				Debug.DrawRay (transform.position, Vector3.down*hit.distance, Color.green);
				hitpoint = hit.point;
				return true;
			}

			else {
				hitpoint=Vector3.zero;
				return false;
			} 
	}
}
