using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {

	public GameObject blinkingLight;
	public float fadeSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		blinkingLight.light.intensity = Mathf.Lerp(fadeSpeed * Time.deltaTime);

	}

}
