using UnityEngine;
using System.Collections;

public class MoveOLD : MonoBehaviour {

	public float speed;

	
	// Update is called once per frame
	void Update () {


		//press w to go up
		if (Input.GetKey (KeyCode.W)) {
			rigidbody2D.AddForce(Vector2.up * speed); // Add rigid body to player game object, set gravity scale to 0, lock rotation.
		}
		//press s to go down
		if (Input.GetKey (KeyCode.S)) {
			rigidbody2D.AddForce(-Vector2.up * speed);
		}
		//press a to go left
		if (Input.GetKey (KeyCode.A)) {
			rigidbody2D.AddForce(-Vector2.right * speed);
		}
		//press d to go right
		if (Input.GetKey (KeyCode.D)) {
			rigidbody2D.AddForce(Vector2.right * speed);
		}


	
	}
}
