using UnityEngine;
using System.Collections;

public class BlinkBehaviour : MonoBehaviour {

	public float rateToBlink;
	private float currentRateToBlink;

	void Start ()
	{
	
	}
	
	void Update () 
	{
		currentRateToBlink += Time.deltaTime;

		if (currentRateToBlink > rateToBlink) {
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
			currentRateToBlink = 0;
		}
	}
}
