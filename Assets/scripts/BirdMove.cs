using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;

    public bool moving = false;

    public float velocity;
    private Rigidbody rb;

	public int i,j;
	bool[,] flagg;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

		flagg = new bool[8, 7];
		flagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().flagg;

		j = (int)(gameObject.transform.position.x + 3.5);
		i = (int)(gameObject.transform.position.z + 3.5);
		i = 7 - i;
    }

	// Update is called once per frame
	void Update () {

		if (right == true)
		{
			rb.AddForce(Vector3.right * velocity, ForceMode.Impulse);
			gameObject.transform.Rotate (new Vector3(0f,0f,-1f)*Time.deltaTime*velocity*1000);
			moving = true;
		}
		else if (left == true)
		{
			rb.AddForce(Vector3.left * velocity, ForceMode.Impulse);
			gameObject.transform.Rotate (new Vector3(0f,0f,1f)*Time.deltaTime*velocity*1000);
			moving = true;
		}
		else if (up == true)
		{
			rb.AddForce(Vector3.forward * velocity, ForceMode.Impulse);
			gameObject.transform.Rotate (Vector3.right*Time.deltaTime*velocity*1000);
			moving = true;
		}
		else if (down == true)
		{
			rb.AddForce(Vector3.back * velocity, ForceMode.Impulse);
			gameObject.transform.Rotate (Vector3.left*Time.deltaTime*velocity*1000);
			moving = true;
		}
		if (moving == false) {
			gameObject.transform.rotation = Quaternion.identity;
		}

    }

    
}
