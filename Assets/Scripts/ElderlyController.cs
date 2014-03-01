using UnityEngine;
using System.Collections;

public class ElderlyController : MonoBehaviour 
{

	public GameObject walker;

	void Start()
	{
		rigidbody.centerOfMass = new Vector3(0,0,.1f);
	}

	void Update()
	{
//		if(Input.GetKeyDown(KeyCode.Z))
//		{
//			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+.5f* Time.deltaTime);
//		}
	}
}
