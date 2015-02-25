using UnityEngine;
using System.Collections;

public class Patrolling : MonoBehaviour {

	public float moveSpeed, patrollingHeight;

	private Vector2 startingPos, up;
	private bool patrolling, patrollingDown, patrollingUp;

	// Use this for initialization
	void Start () {
		patrolling = true;
		startingPos = transform.position;
		up = new Vector2 (0, moveSpeed);
	
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
