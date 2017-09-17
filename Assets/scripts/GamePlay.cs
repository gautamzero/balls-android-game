using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour {
	public GameObject ball;
	public GameObject touchedBall;
	GameObject preBall;

	public int no_of_balls;
	public int ballsleft;

	public Text ballsLeft;
	public Text timeLeft;
	public Text Score;

	public bool[,] flagg;
	public bool[,] mainFlagg;
	bool preData;
	bool restart;
	public bool survival;
	public int time;
	public int score;

	void Awake(){
		//for music
		GameObject ob1 = GameObject.FindGameObjectWithTag("music") as GameObject;
		Destroy (ob1);

		//for game data
		GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue")[0] as GameObject;
		Debug.Log ("------>"+ob);
		no_of_balls = ob.GetComponent<PassValueScript> ().no_of_balls;
		preData = ob.GetComponent<PassValueScript> ().fromPause;
		restart = ob.GetComponent<PassValueScript> ().restart;
		survival = ob.GetComponent<PassValueScript> ().survival;
		time = ob.GetComponent<PassValueScript> ().time;
		score = ob.GetComponent<PassValueScript> ().score;

		Debug.Log ("resume " + preData + " restart " + restart);
		if (preData) {
			flagg = new bool[8, 7];
			mainFlagg = new bool[8, 7];
			flagg = ob.GetComponent<PassValueScript> ().flagg;
			ballsleft = ob.GetComponent<PassValueScript> ().ballsleft;
			mainFlagg = ob.GetComponent<PassValueScript> ().mainFlagg;
		}
		if (restart) {
			flagg = new bool[8, 7];
			mainFlagg = new bool[8, 7];
			mainFlagg = ob.GetComponent<PassValueScript> ().mainFlagg;
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j < 7; j++)
				{
					if (mainFlagg [i, j] == true) {
						flagg [i, j] = true;
					} else
						flagg [i, j] = false;
				}
			}
			ballsleft = no_of_balls;
		}
		Destroy (ob);
	}

	// Use this for initialization
	void Start () {
		if (preData == false && restart == false) {
			
			flagg = new bool[8, 7];
			mainFlagg = new bool[8, 7];
			randomGenerate ();
			ballsleft = no_of_balls;
		}
		float[,] posx = new float[8, 7];
		float[,] posy = new float[8, 7];
		float x;
		float y = 4.5f;
		for (int i = 0; i < 8; i++) {
			y -= 1;
			x = -4.5f;
			for (int j = 0; j < 7; j++) {
				x += 1;
				posx [i, j] = x;
				posy [i, j] = y;
			}
		}

		for(int i=0;i<8;i++){
			for(int j=0;j<7;j++){
				if(flagg[i,j] == true){
					Vector3 pos = new Vector3(posx[i,j],0.5f,posy[i,j]);
					Debug.Log (i+" "+ j);
					GameObject ballIns = GameObject.Instantiate (ball, pos, Quaternion.identity) as GameObject;

				}
			}
		}

		if(survival)
			InvokeRepeating ("updateTime", 1.0f, 1.0f);
	}

	//updates time per second
	void updateTime(){
		time -= 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (survival) {
			Score.text = "Score : " + score;
			timeLeft.text = "Time Left : " + time;
		} else {
			ballsLeft.text = "Balls Left : " + ballsleft;
		}

		/*
		if (preBall == null && touchedBall != null)
			preBall = touchedBall;
		else {
			if (preBall != touchedBall) {
				preBall.GetComponent<BirdMovement> ().reset ();
				preBall = null;
			}
		}
		*/


		if (time == 0 && survival == true) {
			GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue") [0] as GameObject;
			ob.GetComponent<PassValueScript> ().no_of_balls = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().no_of_balls;
			ob.GetComponent<PassValueScript> ().score = score;
			ob.GetComponent<PassValueScript> ().time = time;
			ob.GetComponent<PassValueScript> ().survival = survival;

			SceneManager.LoadScene ("TimeOver");
		}


		if (ballsleft == 1) {

			if (survival == true) {
				score += 5 * no_of_balls;
				Score.text = "Score : " + score;
				time = time + (int)(time / 4);

				if (time > 30)
					time = 30;
				else if (time < 10)
					time = 10;
				
				if (score > 400)
					no_of_balls = 6;
				else if (score > 200)
					no_of_balls = 5;
				else if (score > 80)
					no_of_balls = 4;
				
				GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue") [0] as GameObject;
				ob.GetComponent<PassValueScript> ().no_of_balls = no_of_balls;
				ob.GetComponent<PassValueScript> ().score = score;
				ob.GetComponent<PassValueScript> ().time = time;
				ob.GetComponent<PassValueScript> ().survival = survival;

				SceneManager.LoadScene ("GamePlayTime");

			} else {

				GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue") [0] as GameObject;

				ob.GetComponent<PassValueScript> ().ballsleft = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().ballsleft;
				ob.GetComponent<PassValueScript> ().no_of_balls = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().no_of_balls;
				ob.GetComponent<PassValueScript> ().mainFlagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().mainFlagg;
				ob.GetComponent<PassValueScript> ().restart = true;

				if (no_of_balls == 3) {
					int c = PlayerPrefs.GetInt ("beg");
					PlayerPrefs.SetInt ("beg", ++c);
				} else if (no_of_balls == 4) {
					int c = PlayerPrefs.GetInt ("amt");
					PlayerPrefs.SetInt ("amt", ++c);
				} else if (no_of_balls == 5) {
					int c = PlayerPrefs.GetInt ("semi");
					PlayerPrefs.SetInt ("semi", ++c);
				} else if (no_of_balls == 6) {
					int c = PlayerPrefs.GetInt ("pro");
					PlayerPrefs.SetInt ("pro", ++c);
				} else if (no_of_balls == 7) {
					int c = PlayerPrefs.GetInt ("leg");
					PlayerPrefs.SetInt ("leg", ++c);
				}

				SceneManager.LoadScene ("NextLevel");
			}

		}
	}

	void randomGenerate()
	{
		int balls = no_of_balls;
		char[,] grid = new char[8,7];

		for (int i = 0; i<8; i++) {
			for (int j = 0; j<7; j++) {
				grid[i,j] = '#';
			}
		}
		int[,] flag = new int[8,7];
		for (int i = 0; i<8; i++) {
			for (int j = 0; j<7; j++) {
				flag[i,j] = 0;
			}
		}
		int x1, y1;
		x1 = Random.Range(0, 8);
		y1 = Random.Range(0,7);

		int h = Random.Range(0,2);
		balls--;
		int x2, y2;
		int l = 1;
		x2 = x1;
		y2 = 0;
		flag[x1,y1] = 1;
		grid[x1,y1] = '@';
		while (balls>0) {
			int sum1, sum2;
			if(x1==x2){
				sum1 = sum2 = 0;
				for (int i = 0; i<8; i++) {
					sum1 = sum1 + flag[i,y1];
				}
				for (int i = 0; i<7; i++) {
					sum2 = sum2 + flag[x1,i];
				}
				if(sum1 == 8 && sum2 == 7){
					for (int i = 0; i<8; i++) {
						if(i!=x1)
							flag[i,y1] = 0;
					}
				}
			}
			else if(y1==y2){
				sum1 = sum2 = 0;
				for (int i = 0; i<8; i++) {
					sum1 = sum1 + flag[i,y1];
				}
				for (int i = 0; i<7; i++) {
					sum2 = sum2 + flag[x1,i];
				}
				if(sum1 == 8 && sum2 == 7){
					for (int i = 0; i<7; i++) {
						if(i!=y1)
							flag[x1,i] = 0;
					}
				}
			}

			int cnt, f;
			if(h==1){
				cnt=0;
				f=0;
				x2 = x1;
				y2 = Random.Range(0,7);
				while(Mathf.Abs(y2-y1)<=1 || flag[x2,y2] == 1){
					y2 = Random.Range(0,7);
					cnt++;

					if(cnt>7){
						f = 1;
						h=0;
						y2 = y1;
						break;
					}
				}
				if(f==1)
					continue;
				flag[x2,y2] = 1;
				l++;
				grid[x2,y2] = '@';
				if(y1<y2){
					for (int i = y1 + 1; i< 7; i++) {
						flag[x2,i] = 1;
					}
					y1 = y2-1;
				}
				else{
					for (int i = 0; i<y1; i++) {
						flag[x2,i] = 1;
					}
					y1 = y2+1;
				}
			}

			else{
				cnt=0;
				f=0;
				x2 = Random.Range(0,8);
				y2 = y1;

				while(Mathf.Abs(x2-x1)<=1 || flag[x2,y2]==1){
					x2 = Random.Range(0,8);
					cnt++;
					if(cnt>8){
						f = 1;
						h=1;
						x2 = x1;
						break;
					}
				}
				if(f==1)
					continue;
				flag[x2,y2] = 1;
				l++;
				grid[x2,y2] = '@';
				if(x1<x2){
					for (int i = x1 + 1; i< 8; i++) {
						flag[i,y2] = 1;
					}
					x1 = x2-1;
				}
				else{
					for (int i = 0; i<x1; i++) {
						flag[i,y2] = 1;
					}
					x1 = x2+1;
				}
			}
			balls--;
			h = Random.Range(0,2);
		}
		for(int i = 0; i < 8; i++)
		{
			for(int j = 0; j < 7; j++)
			{
				if (grid[i, j] == '@')
					flagg[i, j] = true;
				else
					flagg[i,j] = false;
			}
		}
		for(int i = 0; i < 8; i++)
		{
			for(int j = 0; j < 7; j++)
			{
				if (flagg [i, j] == true) {
					mainFlagg [i, j] = true;
				} else
					mainFlagg [i, j] = false;
			}
		}
	}

}
