using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public Transform mesh;
	public float forceFly;
	private Animator animatorPlayer;

	private float currentTimeToAnim;
	private bool inAnim;

	void Start () {
		animatorPlayer = mesh.GetComponent<Animator> ();
	}
	
	void Update () {

		if (Input.GetMouseButtonDown (0)) 
		{
			inAnim = true;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 1) * forceFly);
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
	
	}
}
