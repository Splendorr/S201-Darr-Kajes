using UnityEngine;
using System.Collections;

public class PlayerControllerElder_RH : MonoBehaviour {

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
		xPosition = transform.position.x;
		zPosition = transform.position.z;
		//rigidbody.centerOfMass = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		// rotates the player using z and x axis rotation
		// player character is built so that the center of 
		// gravity is centered on the feet to model off balanced wobbliness.
		rotatePlayerCharacter();

	}

	void rotatePlayerCharacter() {

		// rotates the player 
		if(!Input.GetKey(KeyCode.LeftShift)) {
			// Move player only when shift key is not pressed.
			
			if(Input.GetKey(KeyCode.A)) {
				// moves player left
				zRotation++;//= Input.GetAxis("Horizontal");
			}
			if(Input.GetKey(KeyCode.D)) {
				// moves player right
				zRotation--;//= Input.GetAxis("Horizontal");
			}
			if(Input.GetKey(KeyCode.W)) {
				// moves player forward
				xRotation++;//= Input.GetAxis("Vertical");
			}
			if(Input.GetKey(KeyCode.S)) {
				// moves player backward
				xRotation--;//= Input.GetAxis("Vertical");
			}
			
			float newRotationX = Mathf.SmoothDamp(transform.position.x, xRotation, ref xVelocity, smoothTime);
			float newRotationZ = Mathf.SmoothDamp(transform.position.z, zRotation, ref zVelocity, smoothTime);
			checkAngle();
			transform.eulerAngles = new Vector3(newRotationX, yRotation, newRotationZ);
		}

	}


	void checkAngle() {

		// controls maximum angle of rotation 
		if(zRotation > 20) {
			zRotation = 20;
		}
		else if(zRotation < -20) {
			zRotation = -20;
		}
		if(xRotation > 30) {
			xRotation = 30;
		}
		else if(xRotation < -5) { 
			xRotation = -5;
		}

	}
}
