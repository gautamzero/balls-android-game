using UnityEngine;
using System.Collections;

public class PassValueScript : MonoBehaviour {

	public int no_of_balls;
	public int ballsleft;
	public bool[,] flagg;
	public bool[,] mainFlagg;
	public bool fromPause;
	public bool restart;
	public bool survival;
	public int time;
	public int score;

	// Use this for initialization
	void Start () {
		flagg = new bool[8, 7];
		mainFlagg = new bool[8, 7];
		fromPause = false;
		restart = false;
		survival = false;
		time = 30;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void reset(){
		flagg = new bool[8, 7];
		mainFlagg = new bool[8, 7];
		fromPause = false;
		restart = false;
	}

	void Awake(){
		DontDestroyOnLoad (this);
	}
}
