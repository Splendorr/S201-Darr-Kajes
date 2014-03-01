using UnityEngine;
using System.Collections;

public class WalkerController : MonoBehaviour 
{
	public bool isOnGround;

	void Update()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			rigidbody.AddRelativeForce(new Vector3(0, -Physics.gravity.y * rigidbody.mass, rigidbody.mass * 5 * Time.deltaTime));
		}
	}
}
