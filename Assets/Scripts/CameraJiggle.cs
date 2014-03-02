using UnityEngine;
using System.Collections;

public class CameraJiggle : MonoBehaviour {
	
	public float zRotation = 0.0f;
	public float yRotation = 0.0f;
	
	public float smoothTime = 0.0F;
	public float yVelocity = 0.0F;
	public float zVelocity = 0.0F;

	//startY was replaced with myElder.centerY
//	public float startY;

	public float startZ;

	public ElderlyController myElder;

	void Awake()
	{
		myElder = transform.root.GetComponent<ElderlyController> ();
	}

	void Start () {
//		startY = transform.eulerAngles.y;
		startZ = transform.eulerAngles.z;
	}

	void Update () {

		getJiggle();
		float newRotationZ = Mathf.SmoothDamp(transform.eulerAngles.z, transform.eulerAngles.z + zRotation, ref zVelocity, smoothTime);
		float newRotationY = Mathf.SmoothDamp(transform.eulerAngles.y, transform.eulerAngles.y + yRotation, ref yVelocity, smoothTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotationY, ClampAngle(newRotationZ, startZ - 10f, startZ + 10f));
		
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
