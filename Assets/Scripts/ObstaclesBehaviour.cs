using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

	public float speed;

	void Start () {
	
	}

	void Update () {
	
		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;

		if (transform.position.x < -5) {
			gameObject.SetActive (false);
		}
	}
}
