using UnityEngine;
using System.Collections;

public enum GameStates {
	START,
	WAITGAME,
	MAINMENU,
	TUTORIAL,
	INGAME,
	GAMEOVER,
	RANKING
}

public class GameController : MonoBehaviour {

	public Transform player;

	private Vector3 startPositionPlayer;

	private GameStates currentState = GameStates.START;


	public GameObject scoreGameObject;
	public TextMesh numberScore;
	public TextMesh shadowScore;

	public float timeToRestart;
	private float currentTimeToRestart;

	private int score;

	private GameOverController gameOverController;

	public GameObject mainMenu;
	public GameObject tutorial;

	private bool canPlay;
	private float currentTimeToPayAgain;


	void Start () {

		gameOverController = FindObjectOfType(typeof(GameOverController)) as GameOverController;

		startPositionPlayer = player.position;
	}

	void Update () {
	
		switch (currentState) {
		case GameStates.START:
			{
				player.position = startPositionPlayer;
				player.gameObject.SetActive (false);
				currentState = GameStates.MAINMENU;
				mainMenu.SetActive (true);
			}
			break;
		case GameStates.MAINMENU:
			{
				player.position = startPositionPlayer;
			}
			break;
		case GameStates.TUTORIAL:
			{
				player.position = startPositionPlayer;
				currentTimeToPayAgain += Time.deltaTime;

				if (currentTimeToPayAgain > 0.2f) {
					currentTimeToPayAgain = 0;
					canPlay = true;
				}

			}
			break;
		case GameStates.WAITGAME:
			{
				player.position = startPositionPlayer;

			}
			break;
		case GameStates.INGAME:
			{
				numberScore.text = score.ToString ();
				shadowScore.text = score.ToString ();			
			}
			break;
		case GameStates.GAMEOVER:
			{
				currentTimeToRestart += Time.deltaTime;
				canPlay = false;
				if (currentTimeToRestart > timeToRestart) 
				{
					currentTimeToRestart = 0;
					gameOverController.SetGameOver (score);
					currentState = GameStates.RANKING;
				}

			}
			break;
		case GameStates.RANKING:
			{
				scoreGameObject.SetActive (false);
				numberScore.text = score.ToString ();
				shadowScore.text = score.ToString ();
			}
			break;
		default:
			break;
		}
	}

	public void StartGame()
	{
		currentState = GameStates.INGAME;
		scoreGameObject.SetActive (true);
		score = 0;
		gameOverController.HideGameOver ();
		tutorial.SetActive (false);
	}

	public GameStates GetCurrentState()
	{
		return currentState;
	}

	public void CallGameOver()
	{
		if (currentState != GameStates.GAMEOVER)
		{
			SoundController.PlaySound (SoundController.soundsGame.hit);
			gameOverController.ShowFade ();
		}
			

		currentState = GameStates.GAMEOVER;
	}

	public void CallTutorial()
	{
		SoundController.PlaySound (SoundController.soundsGame.menu);
		gameOverController.HideGameOver ();
		currentState = GameStates.TUTORIAL;
		mainMenu.SetActive (false);
		tutorial.SetActive (true);
		player.gameObject.SetActive (true);
		ResetGame ();
	}

	public void ResetGame()
	{
		player.position = startPositionPlayer;
		player.GetComponent<PlayerBehaviour> ().RestartRotation ();
		ObstaclesBehaviour[] pipes = FindObjectsOfType (typeof(ObstaclesBehaviour)) as ObstaclesBehaviour[];
		foreach (ObstaclesBehaviour ob in pipes) 
		{
			ob.gameObject.SetActive (false);
		}

	}

	public void AddScore()
	{
		score++;
		SoundController.PlaySound (SoundController.soundsGame.point);
	}

	public bool CanPlay(){
		return canPlay;
	}


}
