using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

	public float speed;

	private GameController gameController;

	void Start () {
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}

	void Update () {

		if (gameController.GetCurrentState () != GameStates.INGAME) 
		{
			return;
		}
	
		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;

		if (transform.position.x < -5) {
			gameObject.SetActive (false);
		}
	}
}
