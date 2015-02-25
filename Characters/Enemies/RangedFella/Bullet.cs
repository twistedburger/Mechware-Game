using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float timeBeforeDeath;

	private float beginning;


	// Use this for initialization
	void Start () {
		beginning = Time.time;
		if (timeBeforeDeath == 0) 
			timeBeforeDeath = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time - beginning > timeBeforeDeath) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player") {
			if((other.transform.position - this.transform.position).magnitude < 0.1f) {
				hurt();
				Destroy(this.gameObject);
			}
		}

		if (!other.CompareTag ("Enemy") && !other.CompareTag("Player")  && !other.CompareTag("CharHitBox")) {
			Destroy (this.gameObject);	
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.name == "Player") {
			if((other.transform.position - this.transform.position).magnitude < 0.1f) {
				hurt();		
				Destroy(this.gameObject);
			}
		}

		if (!other.CompareTag ("Enemy") && !other.CompareTag("Player") && !other.CompareTag("CharHitBox")){
			Destroy (this.gameObject);	
		}
	}

	void hurt() {

	}
}
