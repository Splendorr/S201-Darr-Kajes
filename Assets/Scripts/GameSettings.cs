using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad(this);			// changing game scenes will destroy everything in the scene 
											// except for the GameObject that this script is attached to
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
