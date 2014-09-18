using UnityEngine;
using System.Collections;

public class LandingSensor : MonoBehaviour {
	public LayerMask platformLayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.x==0)//I check the landing only if I'm perfectly horizontal
		{
			Ray ray = new Ray (transform.position, Vector3.down);
			RaycastHit hit;


			if (Physics.Raycast(ray, out hit, Mathf.Infinity, platformLayer))
			{
				Debug.DrawRay (transform.position, Vector3.down*hit.distance, Color.green);
			}
		}//end X rotation check
	}
}
