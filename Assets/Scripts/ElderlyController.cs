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
	public bool hasWalker = true;

	//This acivates to prevent accidentally dropping the walker.
	public bool reachLimit = false;

	//FLOATS

	public float playerSpeed = 10.0f;

	public float footCooldown = 0.0001f;

	float newXRot, newZRot;

	void Start()
	{
		rigidbody.centerOfMass = new Vector3(0,0,.1f);
		newXRot = transform.rotation.eulerAngles.x;
		newZRot = transform.rotation.eulerAngles.z;
	}

	void Update()
	{
		if(hasWalker)
		{
			if(walker.GetComponent<WalkerController>().isOnGround &&
			   hasWalker)
			{
				rigidbody.useGravity = false;
				rigidbody.freezeRotation = true;
				rigidbody.drag = 5;

				//Rights self if rotation is off
				if(transform.rotation.eulerAngles.x > 0.0f &&
				   transform.rotation.eulerAngles.x <= 180.0f)
				{
					newXRot = transform.rotation.eulerAngles.x - 0.04f;
				}
				if(transform.rotation.eulerAngles.x <= 360.0f &&
				   transform.rotation.eulerAngles.x > 180.0f)
				{
					newXRot = transform.rotation.eulerAngles.x + 0.04f;
				}
				if(transform.rotation.eulerAngles.z > 0.0f &&
				   transform.rotation.eulerAngles.z <= 180.0f)
				{
					newZRot =  transform.rotation.eulerAngles.z - 0.04f;
				}
				if(transform.rotation.eulerAngles.z <= 360.0f &&
				   transform.rotation.eulerAngles.z > 180.0f)
				{
					newZRot = transform.rotation.eulerAngles.z + 0.04f;
				}
				transform.rotation = Quaternion.Euler(newXRot, 0, newZRot);
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
				rigidbody.drag = 30;
			}
			if(!walker.GetComponent<WalkerController>().isOnGround &&
			   hasWalker)
			{
				if (Input.GetKeyDown (KeyCode.X) &&
				    rightFootReady)
				{
					rightFootReady = false;
					rigidbody.AddRelativeForce(new Vector3(1f, 0, 1) * (playerSpeed/2));
					StartCoroutine(Turn(Quaternion.identity, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 5, transform.rotation.eulerAngles.z), footCooldown));
					StartCoroutine(RightFootCooler());
				}
				else if (Input.GetKeyDown (KeyCode.Z) &&
				         leftFootReady)
				{
					leftFootReady = false;
					rigidbody.AddRelativeForce(new Vector3(-1f, 0, 1) * (playerSpeed/2));
					StartCoroutine(Turn(Quaternion.identity, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 5, transform.rotation.eulerAngles.z), footCooldown));
					StartCoroutine(LeftFootCooler());
				}
			}
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.X) &&
			    rightFootReady)
			{
				rightFootReady = false;
				rigidbody.AddRelativeForce(new Vector3(1f, 0, 1) * playerSpeed);
				StartCoroutine(RightFootCooler());
			}
			else if (Input.GetKeyDown (KeyCode.Z) &&
			         leftFootReady)
			{
				leftFootReady = false;
				rigidbody.AddRelativeForce(new Vector3(-1f, 0, 1) * playerSpeed);
				StartCoroutine(LeftFootCooler());
			}
		}
		if(!rightFootReady &&
		   !leftFootReady)
		{
			rigidbody.AddForce(new Vector3(Random.Range(-playerSpeed, playerSpeed), 0, Random.Range(-playerSpeed, playerSpeed)));
		}
	}

	IEnumerator Turn(Quaternion start, Quaternion end, float time)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < time)
		{
			transform.rotation = Quaternion.Lerp(start, end, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Too Close") &&
		   hasWalker)
		{
			touchingWalker = true;
		}
		else if(col.CompareTag("Reach Limit"))
		{
			Debug.Log ("Back in.");
			reachLimit = false;
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
		else if(col.CompareTag("Reach Limit"))
		{
			Debug.Log ("Reach limit!");
			reachLimit = true;
		}
	}

	void DropWalker(Transform walkerTrans)
	{
		walker.rigidbody.freezeRotation = false;
		hasWalker = false;
		touchingWalker = false;
		rigidbody.freezeRotation = false;
		rigidbody.drag = 0;
		rigidbody.useGravity = true;
		walker.rigidbody.centerOfMass = new Vector3 (0, 1, 1);
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
