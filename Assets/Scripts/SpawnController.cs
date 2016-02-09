using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	public float maxHeight;
	public float minHeight;

	public float rateSpawn;
	private float currentRateSpawn;

	public GameObject tubePreFab;

	public int maxSpawnTubes;

	public List<GameObject> tubes;

	private GameController gameController;

	void Start () {

		for (int i = 0; i < maxSpawnTubes; i++) 
		{
			GameObject tempTube = Instantiate (tubePreFab) as GameObject;
			tubes.Add (tempTube);
			tempTube.SetActive (false);
		}

		currentRateSpawn = rateSpawn;

		gameController = FindObjectOfType (typeof(GameController)) as GameController;

	
	}

	void Update () {

		if (gameController.GetCurrentState () != GameStates.INGAME) 
		{
			return;
		}

		currentRateSpawn += Time.deltaTime;
		if (currentRateSpawn > rateSpawn) {
			currentRateSpawn = 0;
			Spawn ();
		}
	
	}

	private void Spawn(){
		float randHeight = Random.Range (minHeight, maxHeight);

		GameObject tempTube = null;

		for (int i = 0; i < maxSpawnTubes; i++) {
			if (tubes [i].activeSelf == false) {
				tempTube = tubes [i];
				break;
			}
		}

		if (tempTube != null) {
			tempTube.transform.position = new Vector3 (transform.position.x, randHeight, transform.position.z);
			tempTube.SetActive (true);
		}
	
	}

}
