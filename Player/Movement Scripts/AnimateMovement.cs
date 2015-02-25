using UnityEngine;
using System.Collections;

public class AnimateMovement : MonoBehaviour
{


		public Animator anim;
		//private bool didDie = true;
		//private bool isdead = false;
		//private bool up = false;
		//private bool down = false;
		//private bool left = false;
		//private bool right = false;
		public int direction = 0;
		public bool isMoving = false;

		void Start ()
		{
				anim = GetComponent<Animator> ();
		}

		void Update ()
		{
				direction = GetComponentInParent<Direction> ().GetDirection (); 
				isMoving = GetComponentInParent<Direction> ().IsMoving (); 
				if (Input.GetMouseButtonDown (0)) {
						if (direction == 1) {
								anim.SetTrigger ("AttackUp");
						}
						if (direction == 2) {
								anim.SetTrigger ("AttackLeft");
						}
						if (direction == 3) {
								anim.SetTrigger ("AttackDown");
						}
						if (direction == 4) {
								anim.SetTrigger ("AttackRight");
						}
				}

				if (direction == 1 && isMoving) { //look up if not looking left or right
						anim.SetBool ("Up", true);
						anim.SetBool ("Down", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
				} else if (direction == 1 && !isMoving) {
						anim.SetBool ("Up", false);
				}
		
				if (direction == 2 && isMoving) { //look left if not looking up or down
						anim.SetBool ("Left", true);
						anim.SetBool ("Right", false);
						anim.SetBool ("Down", false);
						anim.SetBool ("Up", false);
				} else if (direction == 2 && !isMoving) {
						anim.SetBool ("Left", false);
				}
		
				if (direction == 4 && isMoving) {//look right if not looking up or down
						anim.SetBool ("Right", true);
						anim.SetBool ("Left", false);
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", false);
				} else if (direction == 4 && !isMoving) {
						anim.SetBool ("Right", false);
				}
		
				if (direction == 3 && isMoving) { //look down if not looking left or right
						anim.SetBool ("Down", true);
						anim.SetBool ("Up", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
				} else if (direction == 3 && !isMoving) {
						anim.SetBool ("Down", false);
				}

				//GetDirection ();

				//if (!isdead) { //make sure player is not dead
	
				/*if (up && !left && !right) { //look up if not looking left or right
						anim.SetBool ("Up", true);
						anim.SetBool ("Down", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
				} else if (!up) {
						anim.SetBool ("Up", false);
				}

				if (left && !up && !down) { //look left if not looking up or down
						anim.SetBool ("Left", true);
						anim.SetBool ("Right", false);
						anim.SetBool ("Down", false);
						anim.SetBool ("Up", false);
				} else if (!left) {
						anim.SetBool ("Left", false);
				}

				if (right && !up && !down) {//look right if not looking up or down
						anim.SetBool ("Right", true);
						anim.SetBool ("Left", false);
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", false);
				} else if (!right) {
						anim.SetBool ("Right", false);
				}

				if (down && !left && !right) { //look down if not looking left or right
						anim.SetBool ("Down", true);
						anim.SetBool ("Up", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
				} else if (!down) {
						anim.SetBool ("Down", false);
				}

				//	if (Input.GetKey (KeyCode.Space)) {
				//		anim.SetBool ("Die", didDie);
				//		anim.SetBool ("Down", false);
				//		anim.SetBool ("Up", false);
				//		anim.SetBool ("Left", false);
				//		anim.SetBool ("Right", false);
				//		isdead = true;
				//		StartCoroutine (wait ());
				//}
				//}*/
		}

		//IEnumerator wait(){
		//	yield return new WaitForSeconds(1);
		//	Destroy(gameObject);
		//	yield break;
		//}

		/*void GetDirection ()
		{
				if (!up && !down) { // if either are true, then player is already moving, and cant change direction
			
						if (Input.GetKey (KeyCode.W)) { //Check if w is pressed. If yes, set up true, down false
								up = true;
								down = false;
						}
						//press s to go down
						if (Input.GetKey (KeyCode.S)) { //Check if s is pressed. If yes, set down true, up false
								down = true;
								up = false;
						}
				} else if (Input.GetKeyUp (KeyCode.W)) { //Stop movement up
						up = false;
				} else if (Input.GetKeyUp (KeyCode.S)) { //stop movement down
						down = false;
				}
		
				if (!left && !right) { // if either are true, then player is already moving, and cant change direction//press a to go left
						if (Input.GetKey (KeyCode.A)) {//Check if A is pressed. If yes, set left true, right false
								left = true;
								right = false;
						}
						//press d to go right
						if (Input.GetKey (KeyCode.D)) {//Check if d is pressed. If yes, set right true, left false 
								right = true;
								left = false;
						} 
				} else if (Input.GetKeyUp (KeyCode.A)) {//stop movement left
						left = false;
				} else if (Input.GetKeyUp (KeyCode.D)) { // stop movement right
						right = false;
				}
		}*/


	
	
	
}
