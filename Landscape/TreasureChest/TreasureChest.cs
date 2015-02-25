using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour {

	public float disBeforeOpening;
	public GameObject drop;
	public bool front,left,right;


	private GameObject player;
	private float release;
	private bool scared;
	private ArrayList things;



	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		things = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<Animator>().GetBool("Scared") && (player.transform.position - transform.position).magnitude < disBeforeOpening && Input.GetMouseButtonDown (0) && release == 0) { 
			GetComponent<Animator> ().SetBool ("Open", true);
			release = Time.time;
		}

		if (GetComponent<Animator> ().GetBool ("Scared") && (player.transform.position - transform.position).magnitude < disBeforeOpening) {
			scared =false;
			things.TrimToSize();
			object[] arr = things.ToArray();
			for(int i = 0; i < arr.Length; i++) {
				if (!arr[i].Equals(null)) {
					if (((GameObject)arr[i]).CompareTag("Enemy")) {
						scared = true;
					}
				}
				else
					things.Remove(arr[i]);
			}
			if (!scared) {
				GetComponent<Animator> ().SetBool ("Scared", false);
			}
		}

		if (Time.time - release > 1.5f && GetComponent<Animator> ().GetBool ("Open") && drop != null) {
			if (front) 
				Instantiate(drop, new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), new Quaternion());
			else if (left)
				Instantiate(drop, new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), new Quaternion());
			else if (right)
				Instantiate(drop, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), new Quaternion());
			else
				Instantiate(drop, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Quaternion());
				
			Destroy(this);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Enemy")) {
			GetComponent<Animator>().SetBool("Scared", true);
		}

		things.Add (other.gameObject);


	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Enemy")) {
			GetComponent<Animator>().SetBool("Scared", true);
		}

		if (!things.Contains (other.gameObject)) {
			things.Add(other.gameObject);	
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Enemy")) {
			GetComponent<Animator>().SetBool("Scared", false);
		}

		things.Remove (other.gameObject);
	}
}
