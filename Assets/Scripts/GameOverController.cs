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

		if (scoreInGame >= 1) {
			medals [0].enabled = true;
		} else if (scoreInGame >= 20) {
			medals [1].enabled = true;
		} else if (scoreInGame >= 30) {
			medals [2].enabled = true;
		} else if (scoreInGame >= 40) {
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
