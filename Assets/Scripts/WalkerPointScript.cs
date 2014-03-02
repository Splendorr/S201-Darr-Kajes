using UnityEngine;
using System.Collections;

public class WalkerPointScript : MonoBehaviour
{
	public WalkerController walker;

	public bool onGround = true;

	void Start()
	{
		walker = transform.root.GetComponent<WalkerController> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("floor"))
		{
			walker.pointsOnGround++;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.CompareTag ("floor"))
		{
			walker.pointsOnGround--;
		}
	}
}
