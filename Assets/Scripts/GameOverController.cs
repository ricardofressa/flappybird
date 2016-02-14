using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public TextMesh score;
	public TextMesh bestscore;
	public Renderer[] medals;

	public GameObject content;
	public GameObject title;
	public GameObject newscore;

	void Start () {

		HideGameOver ();
	
	}

	void Update () {
	
	}

	public void SetGameOver(int scoreInGame)
	{
		if (scoreInGame > PlayerPrefs.GetInt ("Score")) 
		{
			PlayerPrefs.SetInt ("Score", scoreInGame);
			newscore.SetActive (true);
		} 
		else
		{
			newscore.SetActive (false);
		}
			

		score.text = scoreInGame.ToString ();
		bestscore.text = PlayerPrefs.GetInt ("Score").ToString ();

		if (scoreInGame >= 10 && scoreInGame <= 24) {
			medals [0].enabled = true;
		} else if (scoreInGame >= 25 && scoreInGame <= 34) {
			medals [1].enabled = true;
		} else if (scoreInGame >= 35 && scoreInGame <= 49) {
			medals [2].enabled = true;
		} else if (scoreInGame >= 50) {
			medals [3].enabled = true;
		}

		content.SetActive (true);
		title.SetActive (true);

	}

	public void HideGameOver()
	{
		title.SetActive (false);
		content.SetActive (false);
		foreach (Renderer m in medals) {
			m.enabled = false;
		}
	}
}
