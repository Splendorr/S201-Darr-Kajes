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

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.LeftShift) &&
		   transform.parent != null &&
		   !elder.GetComponent<ElderlyController>().reachLimit)
		{
			rigidbody.AddRelativeForce(new Vector3(0, -Physics.gravity.y * rigidbody.mass + rigidbody.drag, rigidbody.mass * 5 * Time.fixedDeltaTime));
		}
		else if(!isOnGround &&
		        transform.parent != null)
		{
			rigidbody.AddRelativeForce(new Vector3(0, (-Physics.gravity.y * rigidbody.mass + rigidbody.drag) * .825f, rigidbody.mass * 5 * Time.fixedDeltaTime));

			if(Input.GetKey(KeyCode.Q))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, .5f, 0), frontLeft.position);
			}
			if(Input.GetKey(KeyCode.E))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, .5f, 0), frontRight.position);
			}
			if(Input.GetKey(KeyCode.A))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, .5f, 0), backLeft.position);
			}
			if(Input.GetKey(KeyCode.D))
			{
				rigidbody.AddForceAtPosition(new Vector3(0, .5f, 0), backRight.position);
			}
		}
		else if(!isOnGround &&
		        transform.parent == null)
		{
			rigidbody.AddForce(new Vector3(0, (Physics.gravity.y * rigidbody.mass + rigidbody.drag) * 2.825f, rigidbody.mass * 5 * Time.fixedDeltaTime));
		}

	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Collision: " + col.collider);
		if(col.collider.CompareTag("floor") && Vector3.Angle(transform.up, Vector3.up) < 70)
		{
			isOnGround = true;
			if(transform.parent != null)
			{
				rigidbody.freezeRotation = true;
			}
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.collider.CompareTag ("floor"))
		{
			isOnGround = false;
			rigidbody.freezeRotation = false;
		}
	}
}
