using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject _pc;
	public GameObject _pc1;
	public GameObject _pc2;

	public GameObject _walker;

	public float xOffset = 0.0f;
	public float yOffset = -0.94f;
	public float zOffset = 0.9f;

	private Vector3 _playerSpawnPointPos;		// this is the place in 3D space where the player spawns
	private Vector3 _playerOneSpawnPointPos;	// this is the place in 3D space where player one spawns
	private Vector3 _playerTwoSpawnPointPos;	// this is the place in 3D space where player two spawns

	private Vector3 _walkerSpawnPointPos;
	private Vector3 _walkerOneSpawnPointPos;
	private Vector3 _walkerTwoSpawnPointPos;

	public bool singlePlayer = false;
	

	// Use this for initialization
	void Start () {

		if(singlePlayer) {
			print("true: " + singlePlayer);

			_playerSpawnPointPos = new Vector3(0.0f, 1.7f, 7.0f);
			_walkerSpawnPointPos = new Vector3(xOffset, yOffset, zOffset);

			_pc = (GameObject) Instantiate(_pc, transform.position, transform.rotation);
			_walker = (GameObject)Instantiate(_walker, transform.position, transform.rotation);
			
			_pc.transform.position = _playerSpawnPointPos;
			_walkerSpawnPointPos = new Vector3(_pc.transform.position.x + xOffset, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
			_walker.transform.position = _walkerSpawnPointPos;
			Debug.Log("Moved to Player Spawn Point");

		} else {
			print("false: " + singlePlayer);
			// 2 player version
			_playerOneSpawnPointPos = new Vector3(1.0f, 1.7f, 7.0f);
			_walkerOneSpawnPointPos = new Vector3(xOffset, yOffset, zOffset);

			_pc1 = (GameObject) Instantiate(_pc1, transform.position, transform.rotation);	
			GameObject _walker1 = (GameObject)Instantiate(_walker, transform.position, transform.rotation);

			_pc1.transform.position = _playerOneSpawnPointPos;
			_pc1.camera.rect = new Rect(0.0f,0.0f,0.49f,1.0f);
			_walkerOneSpawnPointPos = new Vector3(_pc1.transform.position.x + xOffset, _pc1.transform.position.y + yOffset, _pc1.transform.position.z + zOffset);
			_walker1.transform.position = _walkerOneSpawnPointPos;
			Debug.Log("Moved to Player1 Spawn Point");

			// 2 player version
			_playerTwoSpawnPointPos = new Vector3(-1.0f, 1.7f, 7.0f);
			_walkerTwoSpawnPointPos = new Vector3(xOffset, yOffset, zOffset);

			_pc2 = (GameObject) Instantiate(_pc2, transform.position, transform.rotation);	
			GameObject _walker2 = (GameObject)Instantiate(_walker, transform.position, transform.rotation);

			_pc2.transform.position = _playerTwoSpawnPointPos;
			_pc2.camera.rect = new Rect(0.5f,0.0f,0.49f,1.0f);
			_walkerTwoSpawnPointPos = new Vector3(_pc2.transform.position.x + xOffset, _pc2.transform.position.y + yOffset, _pc2.transform.position.z + zOffset);
			_walker2.transform.position = _walkerTwoSpawnPointPos;
			Debug.Log("Moved to Player2 Spawn Point");

		}
	}

}
