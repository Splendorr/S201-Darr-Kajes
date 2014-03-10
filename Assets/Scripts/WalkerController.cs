using UnityEngine;
using System.Collections;

public class WalkerController : MonoBehaviour 
{
	public bool isOnGround = true;

	public GameObject elder;

	public Transform frontLeft;
	public Transform frontRight;
	public Transform backLeft;
	public Transform backRight;

	//INTS

	//+1 for each of the 4 points on the ground.  needs to be 4 for the walker to be "grounded".
	public int pointsOnGround = 0;

	public delegate void SoundEventHandler();
	public static event SoundEventHandler Lift;

	bool lifting = false;


	//FLOATS

	public float newXRot;

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.LeftShift) &&
		   !elder.GetComponent<ElderlyController>().reachLimit)
		{
			if(!lifting)
			{
				if(Lift!=null) Lift();
				lifting = true;
			}

			rigidbody.AddForce(new Vector3(0, -Physics.gravity.y * rigidbody.mass + rigidbody.drag, rigidbody.mass * 30 * Time.fixedDeltaTime));
			newXRot = transform.rotation.eulerAngles.x + 0.15f;
			transform.rotation = Quaternion.Euler(newXRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		}
		else if(!isOnGround &&
		        elder.GetComponent<ElderlyController>().hasWalker)
		{
			lifting = false;
			if(!elder.GetComponent<ElderlyController>().reachLimit)
			{
				rigidbody.AddForce(new Vector3(0, (-Physics.gravity.y * rigidbody.mass + rigidbody.drag) * .825f, rigidbody.mass * 20 * Time.fixedDeltaTime));
			}
			else
			{
				rigidbody.AddForce(new Vector3(0, (-Physics.gravity.y * rigidbody.mass + rigidbody.drag) * .825f, 0));
			}

			//Center the walker in front of the elder.


			//Rights self if rotation is off
			if(transform.rotation.eulerAngles.x > 0.0f &&
			   transform.rotation.eulerAngles.x <= 180.0f)
			{
				newXRot = transform.rotation.eulerAngles.x - 0.2f;
				transform.rotation = Quaternion.Euler(newXRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			}
			if(transform.rotation.eulerAngles.x <= 360.0f &&
			   transform.rotation.eulerAngles.x > 180.0f)
			{
				newXRot = transform.rotation.eulerAngles.x + 0.2f;
				transform.rotation = Quaternion.Euler(newXRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			}


			if(Input.GetKey(KeyCode.Q))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, 2, 0), frontLeft.position);
			}
			if(Input.GetKey(KeyCode.E))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, 2, 0), frontRight.position);
			}
			if(Input.GetKey(KeyCode.A))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, 2, 0), backLeft.position);
			}
			if(Input.GetKey(KeyCode.D))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, 2, 0), backRight.position);
			}
		}

		else if(!isOnGround &&
		        !elder.GetComponent<ElderlyController>().hasWalker)
		{
			rigidbody.AddForce(new Vector3(0, (Physics.gravity.y * rigidbody.mass + rigidbody.drag) * 2.825f, rigidbody.mass * 20 * Time.fixedDeltaTime));
		}
		if(pointsOnGround >= 4)
		{
			isOnGround = true;
			if(elder.GetComponent<ElderlyController>().hasWalker)
			{
				rigidbody.freezeRotation = true;
			}
		}
		else
		{
			isOnGround = false;
			rigidbody.freezeRotation = false;
		}
	}
}
