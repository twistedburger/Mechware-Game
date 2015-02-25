using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int health, amountOfExpToPlayer;

	// paralyzedTime and poisonedTime are manipulated by other codes, while poisonTIme and paralyzeTime are the amount of time thing will stay unhealthy
	public float hitForce, paralyzedTime, poisonedTime, poisonTime, paralyzeTime; 

	public bool poisoned = false, berserk = false, paralyzed = false;

	// manipulated by other scripts
	public Vector2 paraPosition;
	public Sprite paraSprite;

	private float deathTimer , poisonTimer;
	private int previousHealth;
	private GameObject player;




	// Use this for initialization
	void Start () {
		if (health == 0) {
			health = 10;		
		}

		poisonTime = 3;
		paralyzeTime = 3;

		player = GameObject.Find ("Player");
		previousHealth = health;

	}
	
	// Update is called once per frame
	void Update () {

		if (poisoned && !(Time.time - poisonedTime > poisonTime)) {
			GetComponent<SpriteRenderer> ().color = Color.green;		
			if (Time.time - poisonTimer > 2) { 							// 2 seconds between poisons
				health -= 1;
				poisonTimer = Time.time;
			}
		} else if (Time.time - poisonedTime > poisonTime) {
			GetComponent<SpriteRenderer> ().color = Color.white;
			poisoned = false;

		}

		if (paralyzed && !(Time.time - paralyzedTime > paralyzeTime)) {
			this.rigidbody2D.position = paraPosition;
			GetComponent<SpriteRenderer>().sprite =paraSprite;
		
		} else if (Time.time - paralyzedTime > paralyzeTime) {
			paralyzed = false;
		}



		if (health <= 0 && !GetComponent<Animator>().GetBool("Die")) {
			GetComponent<Animator>().SetBool("Die",true);
			deathTimer = Time.time;

		}
		// If you want knock back
		/*
		if (previousHealth != health) {
			Vector2 dir =  transform.position - player.transform.position;
			Debug.Log(dir);
			dir = dir / dir.magnitude;
			this.rigidbody2D.AddForce( dir * hitForce);
		}
		
		previousHealth = health;
		*/

		if (GetComponent<Animator>().GetBool("Die") && Time.time - deathTimer > 0.5) {
			player.GetComponent<Status>().exp += amountOfExpToPlayer;
			GameObject.Destroy(this.gameObject);
		}
	}
}
