using UnityEngine;
using System.Collections;

public class WalkerController_RH : MonoBehaviour {

	public float xRotation = 0.0f;
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	public float speed = 0.0f;
	private float xPosition;
	private float zPosition;
	
	public float smoothTime = 0.0F;
	public float xVelocity = 0.0F;
	public float zVelocity = 0.0F;
	private float _cycle = 5.0f;

	// Use this for initialization
	void Start () {
		xPosition = transform.position.x;
		zPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		// rotates the walker object to model 
		// a person moving a walker.
		rotateWalker();
	}

	void rotateWalker() {

		// rotates the walker on z and x axis rotation
		if(Input.GetKey(KeyCode.LeftShift)) {
			// Move walker only when shift key is pressed.
			
			if(Input.GetKey(KeyCode.Q)) {
				// moves walker left and forward
				zRotation--; 
				xRotation--;
			}
			if(Input.GetKey(KeyCode.E)) {
				// moves walker right and forward
				zRotation++; 
				xRotation--;
			}
			if(Input.GetKey(KeyCode.A)) {
				// moves walker left and backward
				zRotation--; 
				xRotation++;
			}
			if(Input.GetKey(KeyCode.D)) {
				// moves walker right and backward
				zRotation++; 
				xRotation++;
			}
			
			float newRotationX = Mathf.SmoothDamp(transform.position.x, xRotation, ref xVelocity, smoothTime);
			float newRotationZ = Mathf.SmoothDamp(transform.position.z, zRotation, ref zVelocity, smoothTime);
			checkAngle();
			transform.eulerAngles = new Vector3(newRotationX, yRotation, newRotationZ);
		}

	}


	void checkAngle() {

		if(zRotation > 20) {
			zRotation = 20;
		}
		else if(zRotation < -20) {
			zRotation = -20;
		}
		if(xRotation > 5) {
			xRotation = 5;
		}
		else if(xRotation < -20) { 
			xRotation = -20;
		}

	}
}
