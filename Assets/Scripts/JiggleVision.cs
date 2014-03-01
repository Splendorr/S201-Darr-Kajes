using UnityEngine;
using System.Collections;

public class JiggleVision : MonoBehaviour {

	public float xRotation = 0.0f;
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	public float speed = 0.0f;
	private float xPosition;
	private float zPosition;
	
	public float smoothTime = 0.0F;
	public float xVelocity = 0.0F;
	public float zVelocity = 0.0F;
	
	// Use this for initialization
	void Start () {
		xPosition = 0;//transform.position.x;
		zPosition = 0;//transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		getJiggle();
		float newRotationX = Mathf.SmoothDamp(transform.position.x, xRotation, ref xVelocity, smoothTime);
		float newRotationZ = Mathf.SmoothDamp(transform.position.z, zRotation, ref zVelocity, smoothTime);
		transform.eulerAngles = new Vector3(newRotationX, yRotation, newRotationZ);

	}

	void getJiggle() {
		xRotation = Random.Range(-2.0f, 2.0f);
		zRotation = Random.Range(-2.0f, 2.0f);
		smoothTime = Random.Range(0.02f, 0.6f);
	}

}
