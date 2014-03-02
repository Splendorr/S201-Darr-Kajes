using UnityEngine;
using System.Collections;

public class CameraJiggle : MonoBehaviour {
	
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	
	public float smoothTime = 0.0F;
	public float yVelocity = 0.0F;
	public float zVelocity = 0.0F;

	public float startY;
	public float startZ;


	void Start () {
		startY = transform.eulerAngles.y;
		startZ = transform.eulerAngles.z;
	}

	void Update () {

		getJiggle();
		float newRotationZ = Mathf.SmoothDamp(transform.eulerAngles.z, transform.eulerAngles.z + zRotation, ref zVelocity, smoothTime);
		float newRotationY = Mathf.SmoothDamp(transform.eulerAngles.y, transform.eulerAngles.y + yRotation, ref yVelocity, smoothTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Clamp(newRotationY, startY - 10f, startY + 10f), Mathf.Clamp(newRotationZ, startZ - 10f, startZ + 10f));
		
	}
	
	void getJiggle() {
		zRotation = Random.Range(-2.0f, 2.0f);
		yRotation = Random.Range(-1.0f, 1.0f);
		smoothTime = Random.Range(0.04f, 1.0f);
	}

}
