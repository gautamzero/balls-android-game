using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

	public Text Beg;
	public Text Amt;
	public Text Semi;
	public Text Pro;
	public Text Leg;
	public Text Best;

	// Use this for initialization
	void Start () {
		Beg.text = "Begginer : " + PlayerPrefs.GetInt("beg") +" puzzles solved";
		Amt.text = "Ametuer : " + PlayerPrefs.GetInt("amt") +" puzzles solved";
		Semi.text = "Semi-pro : " + PlayerPrefs.GetInt("semi") +" puzzles solved";
		Pro.text = "Pro : " + PlayerPrefs.GetInt("pro") +" puzzles solved";
		Leg.text = "Legend : " + PlayerPrefs.GetInt("leg") +" puzzles solved";
		Best.text = "Best Score : " + PlayerPrefs.GetInt ("best");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
