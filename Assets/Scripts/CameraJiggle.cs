using UnityEngine;
using System.Collections;

public class CameraJiggle : MonoBehaviour {

	public float xRotation = 0.0f;
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	public float speed = 0.0f;
//	private float xPosition = 0.0f;
//	private float zPosition = 0.0f;
	
	public float smoothTime = 0.0F;
	public float yVelocity = 0.0F;
	public float zVelocity = 0.0F;
	
	public float nextupdate = 0.0f;

	// Use this for initialization
	void Start () {
//		xPosition = transform.position.x;
//		zPosition = transform.position.z;
//		jigCamera = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		getJiggle();
		float newRotationZ = Mathf.SmoothDamp(transform.eulerAngles.z, transform.eulerAngles.z + zRotation, ref zVelocity, smoothTime);
		float newRotationY = Mathf.SmoothDamp(transform.eulerAngles.y, transform.eulerAngles.y + yRotation, ref yVelocity, smoothTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotationY, newRotationZ);
		
	}
	
	void getJiggle() {
		zRotation = Random.Range(-2.0f, 2.0f);
		yRotation = Random.Range(-1.0f, 1.0f);
		smoothTime = Random.Range(0.04f, 1.0f);
	}

}
