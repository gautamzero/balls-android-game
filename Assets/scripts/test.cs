using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	void Awake(){
		GameObject ob = GameObject.FindGameObjectsWithTag ("passvalue")[0] as GameObject;
		Debug.Log ("------>"+ob);
	}
}
