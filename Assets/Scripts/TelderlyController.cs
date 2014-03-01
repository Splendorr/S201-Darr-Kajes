using UnityEngine;
using System.Collections;

public class TelderlyController : MonoBehaviour 
{

	public GameObject walker;

	//INTS

	public int playerSpeed = 10;

	//BOOLS

	//Which foot needs to be moved in order to advance.  Should pressing the same button twice cause a trip?
	private bool rightFootReady = true;

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.X) &&
			rightFootReady)
		{
			rightFootReady = false;
			Debug.Log ("Right foot!");
			rigidbody.AddForce(Vector3.forward * playerSpeed);
		}
		else if (Input.GetKeyDown (KeyCode.Z) &&
			!rightFootReady)
		{
			rightFootReady = true;
			Debug.Log ("Left foot!");
			rigidbody.AddForce(Vector3.forward * playerSpeed);
		}
	}
}
