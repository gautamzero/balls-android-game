using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    bool touched = false;
    public bool moving = false;

    public float maxTime;
    public float minDist;

    float startTime;
    float endTime;

    Vector2 startPos;
    Vector2 endPos;

    float swipeDist;
    float swipeTime;

    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;

	bool[,] flagg;
	int i,j;


	// Use this for initialization
	void Start () {

		flagg = new bool[8, 7];
		flagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().flagg;

		j = (int)(gameObject.transform.position.x + 3.5);
		i = (int)(gameObject.transform.position.z + 3.5);
		i = 7 - i;

	}
	
	// Update is called once per frame
	void Update () {
		if (moving == false) {

			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Began) {
					startTime = Time.time;
					startPos = touch.position;
				} else if (touch.phase == TouchPhase.Ended) {
					endTime = Time.time;
					endPos = touch.position;

					swipeDist = (endPos - startPos).magnitude;
					swipeTime = endTime - startTime;

					if (swipeTime < maxTime && swipeDist > minDist && touched == true) {
						if (isAllFalse ())
							swipe ();

						j = (int)(gameObject.transform.position.x + 3.5);
						i = (int)(gameObject.transform.position.z + 3.5);
						i = 7 - i;

						flagg = GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().flagg;

						checkRowsCols ();

						if (i + 1 < 8) {
							if (flagg [i + 1, j] == true) {
								down = false;
							}

						}
						if (i - 1 >= 0) {
							if (flagg [i - 1, j] == true) {
								up = false;
							}

						}
						if (j + 1 < 7) {
							if (flagg [i, j + 1] == true) {
								right = false;
							}
						}
						if (j - 1 >= 0) {
							if (flagg [i, j - 1] == true) {
								left = false;
							}
						}
						gameObject.GetComponent<BirdMove> ().up = up;
						gameObject.GetComponent<BirdMove> ().down = down;
						gameObject.GetComponent<BirdMove> ().left = left;
						gameObject.GetComponent<BirdMove> ().right = right;

						moving = true;

						if (isAllFalse ())
							moving = false;
					}
				}
			}

			if (moving == true)
				reset ();
		}
    }

	void checkRowsCols(){
		int k;
		bool f = false;
		for (k = i + 1; k < 8; k++) {
			if (flagg [k, j] == true)
				f = true;
		}
		if (f == false)
			down = false;
		f = false;

		for (k = i - 1; k >= 0; k--) {
			if (flagg [k, j] == true)
				f = true;
		}
		if (f == false)
			up = false;
		f = false;

		for (k = j + 1; k <7; k++) {
			if (flagg [i, k] == true)
				f = true;
		}
		if (f == false)
			right = false;
		f = false;

		for (k = j - 1; k >= 0; k--) {
			if (flagg [i, k] == true)
				f = true;
		}
		if (f == false)
			left = false;
		f = false;

	}


    void OnMouseOver() {

		touched = true;
		/*
        if(Input.touchCount > 0) {

            Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
                Debug.Log("touched");
				//GameObject.FindGameObjectWithTag ("gameobject").GetComponent<GamePlay> ().touchedBall = gameObject;
                touched = true;
            }
        }
        */
    }

    void swipe() {
        Vector2 distance = endPos - startPos;
        
        if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y)) {
            if(distance.x > 0){
                right = true;
                Debug.Log("right");
            }
            else {
                left = true;
                Debug.Log("left");
            }
        }
        else {
            if (distance.y > 0)
            {
                up = true;
                Debug.Log("up");
            }
            else
            {
                down = true;
                Debug.Log("down");
            }
        }
    }

    public void reset() {
        touched = false;
        right = false;
        left = false;
        up = false;
        down = false;
    }

    bool isAllFalse()
    {
        if (up == false && down == false && right == false && left == false)
        {
            return true;
        }
        return false;
    }


}
