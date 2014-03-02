using UnityEngine;
using System.Collections;

public class CameraJiggle : MonoBehaviour {

	public float xRotation = 0.0f;
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	public float speed = 0.0f;
	private float xPosition = 0.0f;
	private float zPosition = 0.0f;
	
	public float smoothTime = 0.0F;
	public float xVelocity = 0.0F;
	public float zVelocity = 0.0F;
	
	public float nextupdate = 0.0f;

	public GameObject camera;

	// Use this for initialization
	void Start () {
		xPosition = transform.position.x;
		zPosition = transform.position.z;
		camera = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {

		getJiggle();
		//xRotation = 31.47588f;
		xRotation = transform.localEulerAngles.x;
		print(xRotation);
		//smoothTime = 0.04f;
		float newRotationZ = Mathf.SmoothDamp(transform.position.z, zRotation, ref zVelocity, smoothTime);
		transform.eulerAngles = new Vector3(xRotation, yRotation, newRotationZ);
		
	}
	
	void getJiggle() {
		zRotation = Random.Range(-2.0f, 2.0f);
		smoothTime = Random.Range(0.04f, 1.0f);
	}

}
