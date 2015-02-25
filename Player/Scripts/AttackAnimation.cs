using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour
{

		public Animator anim;
		public Animator parentAnim;
		private bool isAttack = false;
		private int direction;
		private GameObject player;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				parentAnim = GetComponentInParent<Animator> ();
				player = GameObject.Find ("Player");
		}

		// Update is called once per frame
		void Update ()
		{


				direction = GetComponentInParent<Direction> ().GetDirection (); 

				if (Input.GetMouseButtonDown (0)) {
						if (direction == 1) {
								GetComponent<SpriteRenderer>().sortingOrder = 0;
								anim.SetTrigger ("AttackUp");
								transform.position = player.transform.position + new Vector3 (0, 0, 1);
						}
						if (direction == 2) {
								GetComponent<SpriteRenderer>().sortingOrder = 1;
								anim.SetTrigger ("AttackLeft");
								;
								transform.position = player.transform.position + new Vector3 (0, 0, 1);
						}
						if (direction == 3) {
								GetComponent<SpriteRenderer>().sortingOrder = 1;
								anim.SetTrigger ("AttackDown");
								transform.position = player.transform.position + new Vector3 (0, 0, 0);
						}
						if (direction == 4) {
								GetComponent<SpriteRenderer>().sortingOrder = 1;
								anim.SetTrigger ("AttackRight");
								transform.position = player.transform.position + new Vector3 (0, 0, 0);
						}
				} else {
						if (direction == 1) {
								anim.SetBool ("Up", true);
								anim.SetBool ("Down", false);
								anim.SetBool ("Left", false);
								anim.SetBool ("Right", false);
						}
						if (direction == 2) {
								anim.SetBool ("Left", true);
								anim.SetBool ("Down", false);
								anim.SetBool ("Up", false);
								anim.SetBool ("Right", false);
						}
						if (direction == 3) {
								anim.SetBool ("Down", true);
								anim.SetBool ("Up", false);
								anim.SetBool ("Left", false);
								anim.SetBool ("Right", false);
						}
						if (direction == 4) {
								anim.SetBool ("Right", true);
								anim.SetBool ("Down", false);
								anim.SetBool ("Left", false);
								anim.SetBool ("Up", false);
						}
				}
		}

		IEnumerator wait (float time)
		{
				yield return new WaitForSeconds (time);
				yield break;
		}

		                     
}

