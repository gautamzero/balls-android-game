using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeOverScript : MonoBehaviour {

	public Text Score;
	public Text Best;
	int score;

	void Awake(){
		GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue")[0] as GameObject;
		score = ob.GetComponent<PassValueScript> ().score;
		Score.text = "Your Score : " + score;
		Best.text = "Best Score : " + PlayerPrefs.GetInt ("best");
	}

	// Use this for initialization
	void Start () {
		int best;
		best = PlayerPrefs.GetInt ("best");
		if (score > best) {
			PlayerPrefs.SetInt ("best", score);
		}
		Best.text = "Best Score : " + PlayerPrefs.GetInt ("best");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
