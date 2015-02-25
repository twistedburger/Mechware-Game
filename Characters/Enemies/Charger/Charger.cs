//*****************************************************************************
// To use this script you have to have an animator attached to this person
// with a "Attacking", "Confused", and "Startled" boolean value that makes the character go
// through an animation when true and goes back to running/idling
// afterwars. I didn't include running or anything like that
// cause I'm lazy as shit.
// Patrolling height is how high you want the person to go up and down the map,
// confusion delay is how long they stay confused while still walking in the same
// direction before they get confused, attack time is how long it's attack lasts
// to walk again after attack, and move speed is self-explanatory. 
// 
// 				PLAYER SPEED CANNOT EQUAL CHARGE SPEED!!!!!!!!!!!!!!!!!!!!!!
// Startled has not been tested.
// Mike
//*****************************************************************************



using UnityEngine;
using System.Collections;

public class Charger : MonoBehaviour {





	public float moveSpeed, patrollingHeight, attackTime, ConfusionDelay, distanceBeforeAttack, distanceBeforeSeen;
	public float chargeDelay, chargeSpeed, supriseDelay;

	private float dis, timeAttacking, confused, timeSuprised;
	private Vector2 dir, startingPos;
	private Vector2 up;
	private bool returning, patrolling, patrollingUp, patrollingDown, charging, following, playerSeen;
	private string tag;

	private GameObject player;
	// Use this for initialization
	void Start () {

		if (moveSpeed == 0) {
			moveSpeed = 0.01f;
		}

		startingPos = transform.position;
		patrolling = true;
		up = new Vector2 (0, moveSpeed);
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		if (!patrolling && !GetComponent<Animator> ().GetBool ("Attacking") && !GetComponent<Animator> ().GetBool ("Startled") && !following) {
				
			GetComponent<Animator> ().SetBool ("Confused", true);
		}


		// Vertical line patrol

		if (patrolling) {
			if (transform.position.y >= startingPos.y + patrollingHeight) {
				this.rigidbody2D.velocity = up*-1;
				patrollingUp = false;
				patrollingDown = true;
			}
			
			if (transform.position.y <= startingPos.y - patrollingHeight) {
				this.rigidbody2D.velocity = up;
				patrollingDown = false;
				patrollingUp = true;
			}

			if (transform.position.y < (startingPos.y + patrollingHeight) && transform.position.y > (startingPos.y - patrollingHeight)) {
				if(patrollingDown) {
					this.rigidbody2D.velocity = up*-1;
				}
				else if(patrollingUp) {
					this.rigidbody2D.velocity = up;
				}
				else {
					this.rigidbody2D.velocity = up;
				
				}
			}
		}

		// Check to see if player can be seen
		if ((this.transform.position - player.transform.position).magnitude <= distanceBeforeSeen)
			playerSeen = true;
		else
			playerSeen = false;

		// Oh I see the player! 
		if (playerSeen && patrolling) {
			// Get startled!
			patrolling = false;
			GetComponent<Animator> ().SetBool ("Startled", true);
			timeSuprised = Time.time;
		}
		// If you can see the player and you're not attacking, follow player
		if(playerSeen && !GetComponent<Animator> ().GetBool("Attacking")) {
			following = true;
			patrolling = false;
			returning = false;
			dir = (player.transform.position - this.transform.position);
			dis = dir.magnitude;
			dir = dir * (1/dis);
			this.rigidbody2D.velocity = dir * moveSpeed;
			
			if(dis < distanceBeforeAttack) {
				GetComponent<Animator> ().SetBool ("Attacking", true);
				timeAttacking = Time.time;
			}
		}

		// If you're following the player but can no longer see him, get confused

		if (following && !playerSeen && !GetComponent<Animator> ().GetBool ("Attacking")) {
			following = false;
			confused = Time.time;
			GetComponent<Animator> ().SetBool ("Confused", true);	
		}

		// Check to see what animator is doing
		//ATTACKING
		if (GetComponent<Animator> ().GetBool ("Attacking") && (Time.time - timeAttacking) < chargeDelay) {
			following = false;
			charging = true;
			this.rigidbody2D.velocity = Vector2.zero;
			dir = (player.rigidbody2D.position - this.rigidbody2D.position);
			dis = dir.magnitude;
			float t = dis/(chargeSpeed - player.rigidbody2D.velocity.magnitude);
			dir = (dis*dir + player.rigidbody2D.velocity *t)/(t*chargeSpeed); // predictive   PLAYER SPEED CANNOT EQUAL CHARGE SPEED
		}

		// Attacking is done
		else if(GetComponent<Animator> ().GetBool("Attacking") && (Time.time - timeAttacking) > attackTime) {
			GetComponent<Animator> ().SetBool ("Attacking", false);
			this.rigidbody2D.velocity = Vector2.zero;
		}

		// Charging is done, attack
		else if (GetComponent<Animator> ().GetBool ("Attacking") && (Time.time - timeAttacking) > chargeDelay) {
			charging = false;
			dir = dir/dir.magnitude;
			this.rigidbody2D.velocity = dir * chargeSpeed;
		}

		// STARTLED/CONFUSION/ALL THAT JAZZ
		if(GetComponent<Animator> ().GetBool("Confused") && (Time.time - confused) > ConfusionDelay) {
			GetComponent<Animator> ().SetBool ("Confused", false);
			dir = (startingPos - new Vector2(this.transform.position.x, this.transform.position.y));
			dis = dir.magnitude;
			dir = dir * (1/dir.magnitude);
			this.rigidbody2D.velocity = dir * moveSpeed;
			returning = true;
		}
		
		if (GetComponent<Animator> ().GetBool ("Attacking") && GetComponent<Animator> ().GetBool ("Confused")) {
			confused = Time.time;		
		}

		if (GetComponent<Animator> ().GetBool("Startled") && (Time.time - timeSuprised) > supriseDelay) {
			GetComponent<Animator> ().SetBool("Startled", false);
		}

		// Returned to home spot after chasing player (or something like that)

		if (!GetComponent<Animator>().GetBool("Attacking") && returning && Mathf.Abs((transform.position.y - startingPos.y)) < 0.01 && Mathf.Abs((transform.position.x - startingPos.x)) < 0.01) {
			patrolling = true;
			returning = false;
			this.rigidbody2D.velocity = up;
		}
		else if (returning) {
			dir = (startingPos - new Vector2(this.transform.position.x, this.transform.position.y));
			dis = dir.magnitude;
			dir = dir * (1/dir.magnitude);
			this.rigidbody2D.velocity = dir * moveSpeed;
		}
	}
}
