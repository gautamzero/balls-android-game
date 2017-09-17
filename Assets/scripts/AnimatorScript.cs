using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}

	public bool IsOpen{
		get{return animator.GetBool ("IsOpen"); }
		set{animator.SetBool ("IsOpen", value); }
	}
	// Update is called once per frame
	void Update () {
	
	}
}
