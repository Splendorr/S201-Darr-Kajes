using UnityEngine;
using System.Collections;

public class CameraJiggleLocal : MonoBehaviour {
	
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	
	public float smoothTime = 0.0F;
	public float yVelocity = 0.0F;
	public float zVelocity = 0.0F;

	public float startY;
	public float startZ;


	void Start () {
		startY = transform.localEulerAngles.y;
		startZ = transform.localEulerAngles.z;
	}

	void Update () {

		getJiggle();
		float newRotationZ = Mathf.SmoothDamp(transform.localEulerAngles.z, transform.localEulerAngles.z + zRotation, ref zVelocity, smoothTime);
		float newRotationY = Mathf.SmoothDamp(transform.localEulerAngles.y, transform.localEulerAngles.y + yRotation, ref yVelocity, smoothTime);
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, ClampAngle(newRotationY, startY - 10f, startY + 10f), ClampAngle(newRotationZ, startZ - 10f, startZ + 10f));
		
	}

	float ClampAngle(float angle, float from, float to) {
		if(angle > 180) angle = 360 - angle;
		angle = Mathf.Clamp(angle, from, to);
		if(angle < 0) angle = 360 + angle;
		
		return angle;
	}
	
	void getJiggle() {
		zRotation = Random.Range(-2.0f, 2.0f);
		yRotation = Random.Range(-1.0f, 1.0f);
		smoothTime = Random.Range(0.04f, 1.0f);
	}

}
