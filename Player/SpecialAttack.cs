using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {

	private string currentAbility;
	private float bbtime = 0, pptime = 0, sstime = 0, sctime = 0; //bigbonktime, paralyzingpoketime, superslamtime, spincycletime
	private float shortTime = 1, longTime = 10, medTime = 5;
	private bool specialReady = true, badGuyInRange = false;
	private ArrayList enemyArray = new ArrayList();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentAbility = GetComponentInParent<AbilitySelect> ().currentAbility;

		if (Input.GetMouseButtonDown (1)) {

			if (currentAbility.Equals ("Big Bonk") && Time.time - bbtime > shortTime) {
				bigBonk ();
				} else if (currentAbility.Equals ("Paralyzing Poke") && Time.time - pptime > medTime) {
							paralyzingPoke ();
			
				} else if (currentAbility.Equals ("Super Slam") && Time.time - sstime > medTime) {
							superSlam ();
			
				} else if (currentAbility.Equals ("Spin Cycle") && Time.time - sctime > longTime) {
							spinCycle ();
		
				}
			}
	}



	// Attacks

	void bigBonk() {
		int damage = Mathf.FloorToInt ((GetComponentInParent<Status> ().attackStrength + Mathf.Pow (GetComponentInParent<Status> ().exp * 2, 2f / 5f)) * 2);
		bbtime = Time.time;
		GetComponentInParent<Animator> ().SetBool ("Big Bonk", true);

		if (enemyArray.Count > 0) {
			GameObject enemy = (GameObject)enemyArray.ToArray () [0];
			if (enemy == null) {
				enemyArray.Remove(enemy);
				enemyArray.TrimToSize();
				bigBonk();

			} else if(enemy.GetComponent<Stats> ().health - damage < 0) {
				enemyArray.Remove(enemy);
				enemy.GetComponent<Stats> ().health -= damage;

			} else {
				enemy.GetComponent<Stats> ().health -= damage;
			}

		}
	}


	void paralyzingPoke() {

		pptime = Time.time;
		int damage = Mathf.FloorToInt((GetComponentInParent<Status> ().attackStrength + Mathf.Pow(GetComponentInParent<Status>().exp*2, 2f/5f)) * 0.75f);
		GetComponentInParent<Animator> ().SetBool ("Paralyzing Poke", true);
		
		if (enemyArray.Count > 0) {
			GameObject enemy = (GameObject)enemyArray.ToArray () [0];
			if (enemy == null) {
				enemyArray.Remove(enemy);
				enemyArray.TrimToSize();
				paralyzingPoke();
			}
			else if(enemy.GetComponent<Stats> ().health - damage < 0) {
				enemyArray.Remove(enemy);
				enemy.GetComponent<Stats> ().health -= damage;
			}
			else {
				enemy.GetComponent<Stats> ().health -= damage;
				paralyze(enemy);
				poison(enemy);
			}
			
		}
	}
	
	void superSlam() {
		sstime = Time.time;
		int damage = Mathf.FloorToInt((GetComponentInParent<Status> ().attackStrength + Mathf.Pow(GetComponentInParent<Status>().exp*2, 2f/5f)) * 1.4f);
		int knockBackDamage = Mathf.CeilToInt((GetComponentInParent<Status> ().attackStrength + Mathf.Pow(GetComponentInParent<Status>().exp*2, 2f/5f)) * 0.1f);
		GetComponentInParent<Animator> ().SetBool ("Super Slam", true);

		bool clearingList = false;
		if (enemyArray.Count > 0) {
			GameObject enemy = (GameObject)enemyArray.ToArray () [0];
			if (enemy == null) {
				enemyArray.Remove(enemy);
				enemyArray.TrimToSize();
				superSlam();
				clearingList = true;
			}
			else if(enemy.GetComponent<Stats> ().health - damage < 0) {
				enemyArray.Remove(enemy);
				enemy.GetComponent<Stats> ().health -= damage;
			}
			else {
				enemy.GetComponent<Stats> ().health -= damage;
			}
		}

		if (enemyArray.Count > 0 && !clearingList) {
			enemyArray.TrimToSize();
			object[] temp = enemyArray.ToArray();

			for(int i = 0; i < enemyArray.Count; i++) {

//				Debug.Log(temp[i]);
				if(temp[i].Equals(null)) {
					enemyArray.Remove(temp[i]);
				}
				else {
					((GameObject)temp[i]).GetComponent<Stats>().health -= knockBackDamage;
					Vector2 dir = ((GameObject)temp[i]).GetComponent<Rigidbody2D>().position - new Vector2(transform.position.x,transform.position.y);
					dir = dir/dir.magnitude;
					((GameObject)enemyArray[i]).GetComponent<Rigidbody2D>().AddForce(dir * 1000);
				}
			}
			enemyArray.TrimToSize();
		}
	}
	
	void spinCycle() {
		int damage = Mathf.FloorToInt((GetComponentInParent<Status> ().attackStrength + Mathf.Pow(GetComponentInParent<Status>().exp*2, 2f/5f)) * 3f);

		if (enemyArray.Count > 0) {
			enemyArray.TrimToSize();
			object[] temp = enemyArray.ToArray();
			
			for(int i = 0; i < enemyArray.Count; i++) {

				if(temp[i].Equals(null)) {
					enemyArray.Remove(temp[i]);
				}
				else {
					((GameObject)temp[i]).GetComponent<Stats>().health -= damage;
					Vector2 dir = ((GameObject)temp[i]).GetComponent<Rigidbody2D>().position - new Vector2(transform.position.x,transform.position.y);
					dir = dir/dir.magnitude;
					((GameObject)enemyArray[i]).GetComponent<Rigidbody2D>().AddForce(dir * 1000);
				}
			}
			enemyArray.TrimToSize();
		}
	}

	// Enemy Ailments
	void paralyze(GameObject enemy) {
		enemy.GetComponent<Stats> ().paralyzed = true;
		enemy.GetComponent<Stats> ().paraPosition = enemy.GetComponent<Rigidbody2D> ().position;
		enemy.GetComponent<Stats> ().paralyzedTime = Time.time;
		enemy.GetComponent<Stats> ().paraSprite = enemy.GetComponent<SpriteRenderer> ().sprite;
	}

	void poison (GameObject enemy) {
		enemy.GetComponent<Stats> ().poisoned = true;
		enemy.GetComponent<Stats> ().poisonedTime = Time.time;
		
	
	}


	// TRIGGERS
	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.CompareTag("Enemy")) {   	
			badGuyInRange = true;
			if(!enemyArray.Contains(other.gameObject)) {
				enemyArray.Add(other.gameObject);
			}

		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Enemy")) {
			badGuyInRange = true;
			if(!enemyArray.Contains(other.gameObject)) {
				enemyArray.Add(other.gameObject);
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		
		if(other.CompareTag("Enemy")) {
			badGuyInRange = false;
			if(enemyArray.Contains(other.gameObject)) {
				enemyArray.Remove(other.gameObject);
			}
		}
	}
}
