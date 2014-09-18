using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	public float smooth;
	public float engineLightIntensity;
	public Color engineOffColor;
	public Color engineLowColor;
	public Color engineHighColor;

	private Color _currentColor;
	private float _currentIntensity;
	// Use this for initialization
	void Start () {
		_currentIntensity=engineLightIntensity/2;
		_currentColor=engineLowColor;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("ThrustLow")){
			_currentIntensity=engineLightIntensity;
			_currentColor = engineLowColor;
		}

		if (Input.GetButtonDown("ThrustHigh"))
		{
			_currentIntensity=engineLightIntensity*2;
			_currentColor = engineHighColor;
		}

		if (Input.GetButtonUp("ThrustLow")||Input.GetButtonUp("ThrustHigh"))
		{
			_currentIntensity=engineLightIntensity/2;
			_currentColor = engineOffColor;
		}

		light.intensity = Mathf.Lerp(light.intensity, _currentIntensity, smooth * Time.deltaTime);
		light.color = Color.Lerp(light.color, _currentColor, smooth * Time.deltaTime);
	}
	
}
