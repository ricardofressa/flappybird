using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public Texture2D pauseImage;
	public Texture2D startImage;

	private GameController gameController;

	public float sizeButton;

	private bool isPaused;


	void Start () 
	{

		gameController = FindObjectOfType (typeof(GameController)) as GameController;
	
	}
	
	void OnGUI()
	{
		if (gameController.GetCurrentState () != GameStates.INGAME)
		{
			if (!isPaused) 
			{
				if (GUI.Button (new Rect (0, 0, sizeButton, sizeButton), pauseImage)) 
				{
					isPaused = true;
				}
			}
		}
	}
}
