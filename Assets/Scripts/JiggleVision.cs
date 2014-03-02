using UnityEngine;
using System.Collections;

public class JiggleVision : MonoBehaviour {

	public float xRotation = 0.0f;
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	public float speed = 0.0f;
//	private float xPosition;
//	private float zPosition;
	
	public float smoothTime = 0.0F;
	public float xVelocity = 0.0F;
	public float zVelocity = 0.0F;
	
	public WalkerController walkerController;
	
	// Use this for initialization
	void Start () {
//		xPosition = 0;//transform.position.x;
//		zPosition = 0;//transform.position.z;
//		walker = gameObject;
		walkerController = GetComponent<WalkerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(!walkerController.isOnGround) {
			getJiggle();
		}
		else
		{
			xRotation = 0f;
			zRotation = 0f;
			smoothTime = 0f;
		}
		float newRotationX = Mathf.SmoothDamp(transform.eulerAngles.x, transform.eulerAngles.x+xRotation, ref xVelocity, smoothTime);
		float newRotationZ = Mathf.SmoothDamp(transform.eulerAngles.z, transform.eulerAngles.z+zRotation, ref zVelocity, smoothTime);
		transform.eulerAngles = new Vector3(newRotationX, transform.eulerAngles.y, newRotationZ);

	}

	void getJiggle() {

		xRotation = Random.Range(-.3f, .3f);
		zRotation = Random.Range(-.3f, .3f);

		if(transform.position.y < -0.6f) {
			// state 1
			smoothTime = Random.Range(0.02f, 0.6f);
		} else {
			//state 2
			smoothTime = Random.Range(0.01f, 0.04f);
		}

	}

}
