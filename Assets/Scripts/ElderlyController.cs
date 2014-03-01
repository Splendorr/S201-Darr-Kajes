using UnityEngine;
using System.Collections;

public class ElderlyController : MonoBehaviour 
{

	public GameObject walker;


	//BOOLS

	//FOOTbools
	public bool rightFootReady = true;
	public bool leftFootReady = true;

	//FLOATS

	public float playerSpeed = 10.0f;

	public float footCooldown = 0.0001f;

	void Start()
	{
		rigidbody.centerOfMass = new Vector3(0,0,.1f);
	}

	void Update()
	{
		if(walker.GetComponent<WalkerController>().isOnGround)
		{
			rigidbody.useGravity = false;
			rigidbody.drag = 5;
			if (Input.GetKeyDown (KeyCode.X) &&
			    rightFootReady)
			{
				rightFootReady = false;
				Debug.Log ("Right foot!");
				rigidbody.AddForce(new Vector3(-1f, 0, 1) * playerSpeed);
				StartCoroutine(RightFootCooler());
			}
			else if (Input.GetKeyDown (KeyCode.Z) &&
			         leftFootReady)
			{
				leftFootReady = false;
				Debug.Log ("Left foot!");
				rigidbody.AddForce(new Vector3(1f, 0, 1) * playerSpeed);
				StartCoroutine(LeftFootCooler());
			}
		}
		else
		{
			rigidbody.useGravity = true;
			rigidbody.drag = 50;
		}
	}

	IEnumerator RightFootCooler()
	{
		yield return new WaitForSeconds(footCooldown);
		rightFootReady = true;
	}
	IEnumerator LeftFootCooler()
	{
		yield return new WaitForSeconds(footCooldown);
		leftFootReady = true;
	}
}
