using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

	public GameObject audioMan;

	IEnumerator wait(string sceneName) {
		
		yield return new WaitForSeconds(0.2f);
		SceneManager.LoadScene (sceneName);
	}

	void Start(){
		audioMan = GameObject.FindGameObjectWithTag ("audioman");

	}

	public void LoadScene(string sceneName){
		audioMan.GetComponent<AudioSource> ().Play();
		StartCoroutine (wait(sceneName));
	}

	public void LoadSceneAd(string sceneName){
		SceneManager.LoadScene (sceneName,LoadSceneMode.Additive);
	}

	public void lvl1_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 3;
		LoadScene (sceneName);
	}

	public void lvl2_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 4;
		LoadScene (sceneName);
	}

	public void lvl3_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 5;
		LoadScene (sceneName);
	}

	public void lvl4_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 6;
		LoadScene (sceneName);
	}

	public void lvl5_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 7;
		LoadScene (sceneName);
	}

	public void survival_btn(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().no_of_balls = 3;
		ob.GetComponent<PassValueScript> ().survival = true;
		ob.GetComponent<PassValueScript> ().time = 30;

		LoadScene (sceneName);
	}
		
	public void pause(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;

		ob.GetComponent<PassValueScript> ().ballsleft = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().ballsleft;
		ob.GetComponent<PassValueScript> ().no_of_balls = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().no_of_balls;
		ob.GetComponent<PassValueScript> ().flagg = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().flagg;
		ob.GetComponent<PassValueScript> ().mainFlagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().mainFlagg;
		ob.GetComponent<PassValueScript> ().fromPause = true;
		ob.GetComponent<PassValueScript> ().time = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().time;
		ob.GetComponent<PassValueScript> ().survival = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().survival;
		ob.GetComponent<PassValueScript> ().score = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().score;
		LoadScene (sceneName);
	}

	public void restart(){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;

		if (ob.GetComponent<PassValueScript> ().survival) {

			ob.GetComponent<PassValueScript> ().no_of_balls = 3;
			ob.GetComponent<PassValueScript> ().time = 30;
			ob.GetComponent<PassValueScript> ().score = 0;
			ob.GetComponent<PassValueScript> ().ballsleft = 3;
			ob.GetComponent<PassValueScript> ().survival = true;

			ob.GetComponent<PassValueScript> ().restart = false;
			ob.GetComponent<PassValueScript> ().fromPause = false;

		} else {
			ob.GetComponent<PassValueScript> ().restart = true;
			ob.GetComponent<PassValueScript> ().fromPause = false;
		}

		if (ob.GetComponent<PassValueScript> ().survival)
			LoadScene ("GamePlayTime");
		else
			LoadScene ("GamePlay");
	}

	public void resume(){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;

		if (ob.GetComponent<PassValueScript> ().survival)
			LoadScene ("GamePlayTime");
		else
			LoadScene ("GamePlay");
	}

	public void restartInGame(){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().ballsleft = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().ballsleft;
		ob.GetComponent<PassValueScript> ().no_of_balls = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().no_of_balls;
		ob.GetComponent<PassValueScript> ().flagg = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().flagg;
		ob.GetComponent<PassValueScript> ().mainFlagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().mainFlagg;
		ob.GetComponent<PassValueScript> ().survival = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().survival;
		ob.GetComponent<PassValueScript> ().time = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().time;
		ob.GetComponent<PassValueScript> ().score = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().score;
		ob.GetComponent<PassValueScript> ().restart = true;


		if (ob.GetComponent<PassValueScript> ().survival)
			LoadScene ("GamePlayTime");
		else
			LoadScene ("GamePlay");

	}

	public void next(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;
		ob.GetComponent<PassValueScript> ().reset ();
		LoadScene (sceneName);
	}

	public void reload(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;

		ob.GetComponent<PassValueScript> ().no_of_balls = GameObject.FindGameObjectWithTag("gameobject").GetComponent<GamePlay>().no_of_balls;
		LoadScene (sceneName);
	}

	public void gotoMainMenu(string sceneName){
		GameObject ob = GameObject.FindGameObjectWithTag ("passvalue") as GameObject;

		Destroy (ob);
		LoadScene (sceneName);
	}

	public void quitBtn(){
		audioMan.GetComponent<AudioSource> ().Play();
		Application.Quit ();
	}
}
