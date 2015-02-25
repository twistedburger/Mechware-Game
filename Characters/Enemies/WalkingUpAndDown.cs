using UnityEngine;
using System.Collections;

public class WalkingUpAndDown : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.rigidbody2D.velocity.y > 0) {
			GetComponent<Animator>().SetBool("WalkingUp", true);
			GetComponent<Animator>().SetBool("WalkingDown", false);
		}

		if (this.rigidbody2D.velocity.y < 0) {
			GetComponent<Animator>().SetBool("WalkingDown", true);
			GetComponent<Animator>().SetBool("WalkingUp", false);	
		}

		if (GetComponent<Animator> ().GetBool ("WalkingDown")) {
			GetComponent<Animator>().SetBool("WalkingUp", false);		
		}

		if (GetComponent<Animator> ().GetBool ("WalkingUp")) {
			GetComponent<Animator>().SetBool("WalkingDown", false);		
		}
	}
}
