using UnityEngine;
using System.Collections;

public class ElderlyController : MonoBehaviour 
{

	public GameObject walker;


	//BOOLS

	//FOOTbools
	private bool rightFootReady = true;
	private bool leftFootReady = true;

	private bool touchingWalker = false;

	//Becomes false after dropping walker.
	private bool hasWalker = true;

	//FLOATS

	public float playerSpeed = 10.0f;

	public float footCooldown = 0.0001f;

	void Start()
	{
		rigidbody.centerOfMass = new Vector3(0,0,.1f);
	}

	void Update()
	{
		if(hasWalker)
		{
			if(walker.GetComponent<WalkerController>().isOnGround)
			{
				rigidbody.useGravity = false;
				rigidbody.freezeRotation = true;
				rigidbody.drag = 5;
				if (Input.GetKeyDown (KeyCode.X) &&
				    rightFootReady &&
				    !touchingWalker)
				{
					rightFootReady = false;
					rigidbody.AddForce(new Vector3(1f, 0, 1) * playerSpeed);
					StartCoroutine(RightFootCooler());
				}
				else if (Input.GetKeyDown (KeyCode.Z) &&
				         leftFootReady &&
				         !touchingWalker)
				{
					leftFootReady = false;
					rigidbody.AddForce(new Vector3(-1f, 0, 1) * playerSpeed);
					StartCoroutine(LeftFootCooler());
				}
			}
			else
			{
				rigidbody.useGravity = true;
				rigidbody.freezeRotation = false;
				rigidbody.drag = 50;
			}
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.X) &&
			    rightFootReady)
			{
				rightFootReady = false;
				rigidbody.AddForce(new Vector3(1f, 0, 1) * playerSpeed);
				StartCoroutine(RightFootCooler());
			}
			else if (Input.GetKeyDown (KeyCode.Z) &&
			         leftFootReady)
			{
				leftFootReady = false;
				rigidbody.AddForce(new Vector3(-1f, 0, 1) * playerSpeed);
				StartCoroutine(LeftFootCooler());
			}
		}
		if(!rightFootReady &&
		   !leftFootReady)
		{
			rigidbody.AddForce(new Vector3(Random.Range(-(playerSpeed), (playerSpeed)), 0, Random.Range(-(playerSpeed/2), (playerSpeed/2))));
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Too Close") &&
		   hasWalker)
		{
			touchingWalker = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.CompareTag("Too Close") &&
		   hasWalker)
		{
			touchingWalker = false;
		}
		else if(col.CompareTag ("Too Far") &&
		        hasWalker)
		{
			Debug.Log ("Dropped it!");
			DropWalker(walker.transform);
		}
	}

	void DropWalker(Transform walkerTrans)
	{
		walkerTrans.parent = null;
		walker.rigidbody.freezeRotation = false;
		hasWalker = false;
		touchingWalker = false;
		rigidbody.freezeRotation = false;
		rigidbody.drag = 10;
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
