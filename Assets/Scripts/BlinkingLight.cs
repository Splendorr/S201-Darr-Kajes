using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {

	public GameObject blinkingLight;

	public float minIntensity = 0.0f;
	public float maxIntensity = 5.0f;
	public float multiplier = 20.0f;

	private float random;

	// Use this for initialization
	void Start () {
		random = Random.Range(10000.0f, 30000.0f);
	}
	
	// Update is called once per frame
	void LateUpdate () {

		float noise = Mathf.PerlinNoise(random, Time.time * multiplier);
		blinkingLight.light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

	}

}
