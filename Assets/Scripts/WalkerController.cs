﻿using UnityEngine;
using System.Collections;

public class WalkerController : MonoBehaviour 
{
	public bool isOnGround = true;

	public Transform frontLeft;
	public Transform frontRight;
	public Transform backLeft;
	public Transform backRight;

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			rigidbody.AddRelativeForce(new Vector3(0, -Physics.gravity.y * rigidbody.mass + rigidbody.drag, rigidbody.mass * 5 * Time.fixedDeltaTime));
		}
		else if(!isOnGround)
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

	}

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == "floor" && Vector3.Angle(transform.up, Vector3.up) < 70)
		{
			isOnGround = true;
			rigidbody.freezeRotation = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.collider.tag == "floor")
		{
			isOnGround = false;
			rigidbody.freezeRotation = false;
		}
	}
}
