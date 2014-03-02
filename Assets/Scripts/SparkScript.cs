using UnityEngine;
using System.Collections;

public class SparkScript : MonoBehaviour
{
	private float lifeSpan;

	void Start()
	{
		lifeSpan = Random.Range (0.01f, 0.1f);
		StartCoroutine (Die ());
	}

	IEnumerator Die()
	{
		yield return new WaitForSeconds (lifeSpan);
		Destroy (gameObject);
	}
}
