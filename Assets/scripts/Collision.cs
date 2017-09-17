using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	bool[,] flagg;
	int i,j;

	// Use this for initialization
	void Start () {
	
		flagg = new bool[8, 7];
		flagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().flagg;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        GameObject ob1,ob2;
        Debug.Log(gameObject);
        if (col.gameObject.tag == "Wall")
        {
			flagg [gameObject.GetComponent<BirdMove> ().i, gameObject.GetComponent<BirdMove> ().j] = false ;
			GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().ballsleft--;
			Destroy (gameObject);
			return;
        }
        if (gameObject.GetComponent<BirdMove>().moving == true)
        {
            ob1 = col.gameObject;
            ob2 = gameObject;
            Debug.Log("gameobject moving");
            Debug.Log(ob1+ " "+ ob2);

			ob2.GetComponent<AudioSource> ().Play ();

            if (ob2.GetComponent<BirdMove>().left)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x + 1f, 0.5f, ob1.transform.position.z);
            }
            else if (ob2.GetComponent<BirdMove>().right)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x - 1f, 0.5f, ob1.transform.position.z);
            }
            else if (ob2.GetComponent<BirdMove>().up)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x, 0.5f, ob1.transform.position.z - 1f);
            }
            else if (ob2.GetComponent<BirdMove>().down)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x, 0.5f, ob1.transform.position.z + 1f);
            }

            ob1.GetComponent<BirdMove>().up = ob2.GetComponent<BirdMove>().up;
            ob1.GetComponent<BirdMove>().down = ob2.GetComponent<BirdMove>().down;
            ob1.GetComponent<BirdMove>().left = ob2.GetComponent<BirdMove>().left;
            ob1.GetComponent<BirdMove>().right = ob2.GetComponent<BirdMove>().right;

            ob2.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ob2.GetComponent<BirdMove>().up = false;
            ob2.GetComponent<BirdMove>().down = false;
            ob2.GetComponent<BirdMove>().left = false;
            ob2.GetComponent<BirdMove>().right = false;
            ob2.GetComponent<BirdMove>().moving = false;
			ob2.GetComponent<BirdMovement>().moving = false;

			j = (int)(ob2.transform.position.x + 3.5);
			i = (int)(ob2.transform.position.z + 3.5);
			i = 7 - i;



			flagg [ob2.GetComponent<BirdMove> ().i, ob2.GetComponent<BirdMove> ().j] = false ;
			flagg [i, j] = true;

			ob2.GetComponent<BirdMove> ().i = i;
			ob2.GetComponent<BirdMove> ().j = j;

        }
        else if(col.gameObject.GetComponent<BirdMove>().moving == true)
        {
            ob1 = gameObject;
            ob2 = col.gameObject;
            Debug.Log("collided object moving");

			ob1.GetComponent<AudioSource> ().Play ();

            if (ob2.GetComponent<BirdMove>().left)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x + 1f, 0.5f, ob1.transform.position.z);
            }
            else if (ob2.GetComponent<BirdMove>().right)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x - 1f, 0.5f, ob1.transform.position.z);
            }
            else if (ob2.GetComponent<BirdMove>().up)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x, 0.5f, ob1.transform.position.z - 1f);
            }
            else if (ob2.GetComponent<BirdMove>().down)
            {
                ob2.transform.position = new Vector3(ob1.transform.position.x, 0.5f, ob1.transform.position.z + 1f);
            }

            ob1.GetComponent<BirdMove>().up = ob2.GetComponent<BirdMove>().up;
            ob1.GetComponent<BirdMove>().down = ob2.GetComponent<BirdMove>().down;
            ob1.GetComponent<BirdMove>().left = ob2.GetComponent<BirdMove>().left;
            ob1.GetComponent<BirdMove>().right = ob2.GetComponent<BirdMove>().right;

            ob2.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ob2.GetComponent<BirdMove>().up = false;
            ob2.GetComponent<BirdMove>().down = false;
            ob2.GetComponent<BirdMove>().left = false;
            ob2.GetComponent<BirdMove>().right = false;
            ob2.GetComponent<BirdMove>().moving = false;
			ob2.GetComponent<BirdMovement>().moving = false;

			j = (int)(ob2.transform.position.x + 3.5);
			i = (int)(ob2.transform.position.z + 3.5);
			i = 7 - i;



			flagg [ob2.GetComponent<BirdMove> ().i, ob2.GetComponent<BirdMove> ().j] = false ;
			flagg [i, j] = true;


			ob2.GetComponent<BirdMove> ().i = i;
			ob2.GetComponent<BirdMove> ().j = j;
        }

    }
}
