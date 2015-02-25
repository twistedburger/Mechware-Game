using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	private bool badGuyInRange;
	private GameObject badGuy, attack;
	private int leftClick, attackStrength;
	
	public string attackingBool, lookingBool;

	// Use this for initialization
	void Start () {
		badGuyInRange = false;
		leftClick = 0;
		attackStrength = GetComponentInParent<Status> ().attackStrength;
		attack = GameObject.Find ("Attack");
	}
	
	// Update is called once per frame
	void Update () {


		if (badGuy == null) {
			badGuyInRange = false;		
		}

		// Regular attacks
		if (badGuyInRange && Input.GetMouseButtonDown(0) && (attack.GetComponentInParent<Animator>().GetBool(attackingBool) || attack.GetComponentInParent<Animator>().GetBool(lookingBool))) {
			if((badGuy.GetComponent<Stats>().health - attackStrength) <= 0) {
				badGuy.GetComponent<Stats>().health -= attackStrength;
				badGuy = null;
				badGuyInRange = false;
			}

			else {
			badGuy.GetComponent<Stats>().health -= attackStrength;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.CompareTag("Enemy")) {   	
			badGuyInRange = true;
			badGuy = other.gameObject;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Enemy")) {
			badGuyInRange = true;
			badGuy = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if(other.CompareTag("Enemy")) {
		   	badGuyInRange = false;
		}
	}
}
