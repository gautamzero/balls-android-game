using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioSource music;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		GameObject[] ob = GameObject.FindGameObjectsWithTag ("music");
		if (ob.Length == 1) {
			music.Play ();
			DontDestroyOnLoad (this);
		}
	}
}
