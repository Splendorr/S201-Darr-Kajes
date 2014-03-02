using UnityEngine;
using System.Collections;

public class WalkerPointScript : MonoBehaviour
{
	public WalkerController walker;

	public bool onGround = true;

	public Transform spark;

	void Start()
	{
		walker = transform.root.GetComponent<WalkerController> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("floor"))
		{
			walker.pointsOnGround++;
			Transform spawn;
			spawn = (Transform)Instantiate(spark, transform.position, Quaternion.identity);
			spawn.parent = transform;
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
