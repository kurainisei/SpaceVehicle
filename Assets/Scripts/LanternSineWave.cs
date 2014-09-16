using UnityEngine;
using System.Collections;

public class LanternSineWave : MonoBehaviour {
	public float rate;
	private Light _light;
	// Use this for initialization
	void Start () {
		_light=GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		float lerpValue = ( Mathf.Sin( Time.timeSinceLevelLoad * rate ) + 1 ) * 0.5f;
		light.intensity = Mathf.Lerp(0,2,lerpValue);
	}
}
