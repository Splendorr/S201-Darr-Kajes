using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject button1Pos;
	public GameObject button2Pos;
	public GameObject buttonQuitPos;

	void OnGUI() {

		if (GUI.Button(new Rect(button1Pos.transform.position.x, button1Pos.transform.position.y, 100, 25), "Single Player")) {
			Application.LoadLevel("SinglePlayerLevel1");
		}

		if (GUI.Button(new Rect(button2Pos.transform.position.x, button2Pos.transform.position.y, 100, 25), "Two Player")) {
			Application.LoadLevel("TwoPlayerLevel1");
		}

		if (GUI.Button(new Rect(buttonQuitPos.transform.position.x, buttonQuitPos.transform.position.y, 100, 25), "Quit")) {
			Application.Quit();
		}

	}

}
