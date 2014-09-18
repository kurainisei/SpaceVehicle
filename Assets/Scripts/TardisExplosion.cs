using UnityEngine;
using System.Collections;

public class TardisExplosion : MonoBehaviour {
	public ParticleSystem explosion;
	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		explosion.transform.position = transform.position;
		explosion.Play ();
		Destroy (gameObject);
	}
}
