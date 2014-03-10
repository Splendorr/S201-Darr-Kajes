using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject button1Pos;
	public GameObject button2Pos;
	public GameObject buttonQuitPos;

	void OnGUI() {

		if (GUI.Button(new Rect( Screen.width*.1f, Screen.height*.68f, 100, 25), "Single Player")) {
			Application.LoadLevel("FinalTesting");
		}

		/*
	 	if (GUI.Button(new Rect(button2Pos.transform.position.x, button2Pos.transform.position.y, 100, 25), "Two Player")) {
			Application.LoadLevel("TwoPlayerLevel1");
		}
		*/

		if (GUI.Button(new Rect(Screen.width*.1f, Screen.height*.75f, 100, 25), "Quit")) {
			Application.Quit();
		}

	}

}
