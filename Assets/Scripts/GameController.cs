using UnityEngine;
using System.Collections;

public enum GameStates {
	START,
	WAITGAME,
	INGAME,
	GAMEOVER,
	RANKING
}

public class GameController : MonoBehaviour {

	public Transform player;

	private Vector3 startPositionPlayer;

	private GameStates currentState = GameStates.START;

	void Start () {

		startPositionPlayer = player.position;
	}

	void Update () {
	
		switch (currentState) {
		case GameStates.START:
			{
				player.position = startPositionPlayer;
				currentState = GameStates.WAITGAME;
			}
			break;
		case GameStates.WAITGAME:
			{
				player.position = startPositionPlayer;
			}
			break;
		case GameStates.INGAME:
			{
				
			}
			break;
		case GameStates.GAMEOVER:
			{
				currentState = GameStates.RANKING;
			}
			break;
		case GameStates.RANKING:
			{
				player.position = startPositionPlayer;
			}
			break;
		default:
			break;
		}
	}

	public void StartGame()
	{
		currentState = GameStates.INGAME;
	}

	public GameStates GetCurrentState()
	{
		return currentState;
	}

	public void CallGameOver()
	{
		currentState = GameStates.GAMEOVER;
		ResetGame ();
	}

	private void ResetGame()
	{
		player.position = startPositionPlayer;
		ObstaclesBehaviour[] pipes = FindObjectsOfType (typeof(ObstaclesBehaviour)) as ObstaclesBehaviour[];
		foreach (ObstaclesBehaviour ob in pipes) 
		{
			ob.gameObject.SetActive (false);
		}

	}


}
