using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
		public Animator anim;
		public float walkingSpeed, runningSpeed;
		private float speed, scale;
		private bool up = false;
		private bool down = false;
		private bool left = false;
		private bool right = false;
		//	public bool isMoving = false;
		// public bool isMovingX = false;
		//public int direction = 0; //up = 1, right = 2, down = 3, left = 4
		//   private bool pressingPrevB = false;
		//private bool pressingUp = false;
		//private bool pressingLeft = false;
		//private bool pressingDown = false;
//	private bool pressingRight = false;
		//
		void Start ()
		{
				anim = GetComponent<Animator> ();
				speed = walkingSpeed;
				scale = runningSpeed / walkingSpeed;
		}
	
		// Update is called once per frame
		void Update ()
		{
				//specialsDown (Input.GetKey (KeyCode.W), Input.GetKey (KeyCode.A), Input.GetKey (KeyCode.S), Input.GetKey (KeyCode.D));
				//pressingPrev (Input.GetKey (KeyCode.W), Input.GetKey (KeyCode.A), Input.GetKey (KeyCode.S), Input.GetKey (KeyCode.D));

				Direction ();
				
				if (Input.GetKey (KeyCode.LeftShift)) {
						speed = runningSpeed;
						anim.speed = scale;
						
				} else {
						speed = walkingSpeed;
			anim.speed = 1;
				
				}
				rigidbody2D.velocity = new Vector2 (0, 0);

				//if (!anim.GetBool ("Die")) { // check if death animation is playing
						
						
				if (up) {
						rigidbody2D.velocity += Vector2.up * speed; //check up, go up
				} 

				if (down) {
						rigidbody2D.velocity += -Vector2.up * speed; //check down, go down
				}	

				if (left) {
						rigidbody2D.velocity += -Vector2.right * speed; //check left, go left
				}

				if (right) {
						rigidbody2D.velocity += Vector2.right * speed; //check right, go right
				}
		}

		/*	if(!isMoving){
				if(up){
					direction = 1;
					isMoving = true;
				}
				if(right){
					direction = 2;
					isMoving = true;
				}
				if(down){
					direction = 3;
					isMoving = true;
				}
				if(left){
					direction = 4;
					isMoving = true;
				}
			if(!up && !down && !left && !right)
			{
				isMoving = false;
			}
			}
		}

		//	}
		
				Debug.Log (GetDirection ());
		Debug.Log ("up is " + up );//+ " and pressingUp is " + pressingUp);
			Debug.Log ("down is " + down);// + " and pressingDown is " + pressingDown);
				Debug.Log ("left is " + left);// + " and pressingLeft is " + pressingLeft);
				Debug.Log ("right is " + right);// + " and pressingRight is " + pressingRight);
		Debug.Log ("is it moving? " + isMoving);

		}*/

		public void Direction ()
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
				}
				if (Input.GetKeyUp (KeyCode.W)) { //Stop movement up
						up = false;
				}
				if (Input.GetKeyUp (KeyCode.S)) { //stop movement down
						down = false;
				}
		
				if (!left && !right) { // if either are true, then player is already moving, and cant change direction
						//press a to go left
						if (Input.GetKey (KeyCode.A)) {//Check if A is pressed. If yes, set left true, right false
								left = true;
								right = false;
						}
						//press d to go right
						if (Input.GetKey (KeyCode.D)) {//Check if d is pressed. If yes, set right true, left false 
								right = true;
								left = false;
						} 
				}
				if (Input.GetKeyUp (KeyCode.A)) {//stop movement left
						left = false;
				}
				if (Input.GetKeyUp (KeyCode.D)) { // stop movement right
						right = false;
				}


		}

		//public int GetDirection(){
		/*	if (anim.GetBool ("Up")) {
			direction = 1;
				}
		if (anim.GetBool ("Right")) {
			direction = 2;
		}
		if (anim.GetBool ("Down")) {
			direction = 3;
		}
		if (anim.GetBool ("Left")) {
			direction = 4;
		}*/
		//return direction;
//	}

/*	public bool IsMoving(){
		return pressingPrevB;
		}

	void specialsDown(bool w, bool a, bool s, bool d) {
		if (!pressingPrevB) {
			if(w)
				direction = 1;
			if(a)
				direction = 2;
			if(s)
				direction = 3;
			if(d)
				direction = 4;
		}
	}

	void pressingPrev(bool w, bool a, bool s, bool d) {
		
		if (w && direction == 1) 
			//pressingPrevB = true;
			pressingUp = true;
		if (a && direction == 2)
			//pressingPrevB = true;
			pressingLeft = true;
		if (s && direction == 3)
			//pressingPrevB = true;
			pressingDown = true;
		if (d && direction == 4)
			pressingRight = true;
			//pressingPrevB = true;
		//if (!w && !a && !s && !d)
			//pressingPrevB = false;
		if (!w) {
			pressingUp = false;
	}
		if (!a) {
			pressingLeft = false;
		}
		if (!s) {
			pressingRight = false;
		}
		if (!d) {
			pressingDown = false;
		}

	
}*/
}


