using UnityEngine;
using System.Collections;

public class TelderlyController : MonoBehaviour 
{

	public GameObject walker;

	//BOOLS

	//Which foot needs to be moved in order to advance.  Should pressing the same button twice cause a trip?
	private bool rightFootReady = true;

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.X) &&
			rightFootReady) {
			Debug.Log ("Right foot!");
		} else if (Input.GetKeyDown (KeyCode.Z) &&
			!rightFootReady)
		{
		}
	}
}
