using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speed;
	private float offset;

	private GameController gameController;

	void Start () {
		currentMaterial = GetComponent<Renderer>().material;

		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}

	void Update () {

		if (gameController.GetCurrentState () != GameStates.INGAME &&
			gameController.GetCurrentState () != GameStates.MAINMENU &&
			gameController.GetCurrentState () != GameStates.TUTORIAL ||
			Time.timeScale != 1) 
		{
			return;
		}
	
		offset += 0.001f;

		currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offset * speed, 0));

	}
}
