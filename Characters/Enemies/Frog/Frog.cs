using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour {

	public Sprite smallestTongue, smallerTongue, smallTongue, longTongue, longerTongue, longestTongue;

	private GameObject player;
	private float tongueTime;
	private Sprite currentTongue;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		GetComponent<SpriteRenderer>().sprite = null;
	}
	
	// Update is called once per frame
	void Update () {
		float dis = distanceToPlayer ();
		if (Time.time - tongueTime > 1 && dis < 6 && GetComponentInParent<Animator>().GetBool("Attacking")) {
			tongueTime = Time.time;

			if(dis < 0.25)
				tongue("smallest");
			else if (dis < 0.75f)
				tongue("smaller");
			else if (dis < 1.25f)
				tongue("small");
			else if (dis < 1.75f)
				tongue("long");
			else if (dis < 2.25f)
				tongue("longer");
			else if (dis < 2.75f)
				tongue("longest");
			else {
				GetComponent<SpriteRenderer>().sprite = null;
				tongueTime = 0;
			}

			transform.rotation = Quaternion.Euler (new Vector3(0, 0, angleBetweenThisAndPlayer ()));

		}

		if (Time.time - tongueTime < 0.1) {
			GetComponent<SpriteRenderer> ().sprite = currentTongue;		
		} else if (1 > Time.time - tongueTime && Time.time - tongueTime > 0.1f) {
			GetComponent<SpriteRenderer>().sprite = null;	
		}


	}

	void tongue(string size) {
		if (size.Equals("smallest")) {
			currentTongue = smallestTongue;		
		}
		if (size.Equals("smaller")) {
			currentTongue = smallerTongue;
		}
		if (size.Equals("small")) {
			currentTongue = smallTongue;
		}
		if (size.Equals("long")) {
			currentTongue = longTongue;
		}
		if (size.Equals("longer")) {
			currentTongue = longerTongue;
		}
		if (size.Equals("longest")) {
			currentTongue = longestTongue;
		}
		tongueTime = Time.time;
	}


	float angleBetweenThisAndPlayer() {
		Vector2 temp = (player.transform.position - this.transform.position);
		float angle = Mathf.Atan (temp.y / temp.x);
		angle = (angle * 180 / (Mathf.PI)) - 90;

		if(temp.x < 0) {
			angle = angle + 180;		
		}

		//Debug.Log (angle + " " + "Temp.x " + temp.x + "temp.mag " + temp.magnitude);
		return angle;
	}

	float distanceToPlayer() {
		Vector2 temp = (player.transform.position - this.transform.position);
		return temp.magnitude;
	}
}
