using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public Transform mesh;
	public float forceFly;
	private Animator animatorPlayer;

	private float currentTimeToAnim;
	private bool inAnim;

	private GameController gameController;

	void Start () {
		animatorPlayer = mesh.GetComponent<Animator> ();

		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	void Update () {

		if (Input.GetMouseButtonDown (0) && gameController.GetCurrentState () == GameStates.INGAME) 
		{
			inAnim = true;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 1) * forceFly);
		} 
		else if(Input.GetMouseButtonDown(0))
		{
				gameController.StartGame();
		}

		if (gameController.GetCurrentState() != GameStates.INGAME && 
			gameController.GetCurrentState() != GameStates.GAMEOVER) 
		{
			GetComponent<Rigidbody2D>().gravityScale = 0;
			return;
		}
		else
		{
				GetComponent<Rigidbody2D>().gravityScale = 1;
		}

		if (inAnim) 
		{
			currentTimeToAnim += Time.deltaTime;

			if (currentTimeToAnim > 0.2f) 
			{
				currentTimeToAnim = 0;
				inAnim = false;
			}
		}

		animatorPlayer.SetBool ("callFly", inAnim);

		if (GetComponent<Rigidbody2D> ().velocity.y < 0) 
		{
			mesh.eulerAngles -= new Vector3 (0, 0, 2f);
			if (mesh.eulerAngles.z < 330 && mesh.eulerAngles.z > 30)
				mesh.eulerAngles = new Vector3 (0, 0, 330);
		}
		else if(GetComponent<Rigidbody2D>().velocity.y > 0)
		{
			mesh.eulerAngles += new Vector3 (0, 0, 2f);

			if (mesh.eulerAngles.z > 30)
				mesh.eulerAngles = new Vector3 (0, 0, 30);
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		gameController.CallGameOver ();
		mesh.eulerAngles += new Vector3 (0, 0, 0);
	}
}
