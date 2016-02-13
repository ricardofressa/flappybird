using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public TextMesh score;
	public TextMesh bestscore;
	public Renderer[] medals;

	public GameObject content;

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
		}

		score.text = scoreInGame.ToString ();
		bestscore.text = PlayerPrefs.GetInt ("Score").ToString ();

		if (PlayerPrefs.GetInt ("Score") > 10) {
			medals [0].enabled = true;
		} else if (PlayerPrefs.GetInt ("Score") > 20) {
			medals [1].enabled = true;
		} else if (PlayerPrefs.GetInt ("Score") > 30) {
			medals [2].enabled = true;
		} else if (PlayerPrefs.GetInt ("Score") > 40) {
			medals [3].enabled = true;
		}

		content.SetActive (true);
	}

	public void HideGameOver()
	{
		content.SetActive (false);
		foreach (Renderer m in medals) {
			m.enabled = false;
		}
	}
}
