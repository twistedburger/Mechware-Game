using UnityEngine;
using System.Collections;

public class AttackD : MonoBehaviour
{

		public Animator anim;
		public Animator parentAnim;
		private bool isAttack = false;
		private int direction;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				parentAnim = GetComponentInParent<Animator> ();
				
		}

		// Update is called once per frame
		void Update ()
		{


				direction = GetComponentInParent<Direction> ().GetDirection (); 

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
		else  {
			if (direction == 1) {
				anim.SetBool ("Up",true);
				anim.SetBool ("Down",false);
				anim.SetBool ("Left",false);
				anim.SetBool ("Right",false);
			}
			if (direction == 2) {
				anim.SetBool ("Left",true);
				anim.SetBool ("Down",false);
				anim.SetBool ("Up",false);
				anim.SetBool ("Right",false);
			}
			if (direction == 3) {
				anim.SetBool ("Down",true);
				anim.SetBool ("Up",false);
				anim.SetBool ("Left",false);
				anim.SetBool ("Right",false);
			}
			if (direction == 4) {
				anim.SetBool ("Right",true);
				anim.SetBool ("Down",false);
				anim.SetBool ("Left",false);
				anim.SetBool ("Up",false);
			}
		}




		/*************************************************************************************


				if (Input.GetKey (KeyCode.Space)) {
						isAttack = true;
						StartCoroutine (wait (1));
						isAttack = false;
				}
				/*if (Input.GetKeyUp (KeyCode.Space)) {
			      StartCoroutine (wait (1));
						isAttack = false;
				}

				if (isAttack) {
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", false);

						//if (parentAnim.GetBool ("Up")) {
						if (direction == 1) {
								anim.SetBool ("AttackUp", true);

						}
						//if (parentAnim.GetBool ("Down")) {
						if (direction == 3) {
								anim.SetBool ("AttackDown", true);

						}
						//if (parentAnim.GetBool ("Left")) {
						if (direction == 2) {
								anim.SetBool ("AttackLeft", true);

						}
						//if (parentAnim.GetBool ("Right")) {
						if (direction == 4) {
								anim.SetBool ("AttackRight", true);

						}

				} else {
						anim.SetBool ("AttackUp", false);
						anim.SetBool ("AttackDown", false);
						anim.SetBool ("AttackLeft", false);
						anim.SetBool ("AttackRight", false);
				}

				if (!isAttack) {
						if (direction == 1) {
								anim.SetBool ("Up", true);
								anim.SetBool ("Right", false);
								anim.SetBool ("Left", false);
								anim.SetBool ("Down", false);
					
				
						}
						//if (parentAnim.GetBool ("Down")) {
						if (direction == 3) {
								anim.SetBool ("Down", true);
								anim.SetBool ("Right", false);
								anim.SetBool ("Up", false);
								anim.SetBool ("Left", false);
							
				
						}
						//if (parentAnim.GetBool ("Left")) {
						if (direction == 2) {
								anim.SetBool ("Left", true);
								anim.SetBool ("Right", false);
								anim.SetBool ("Up", false);
								anim.SetBool ("Down", false);
								
						}
						//if (parentAnim.GetBool ("Right")) {
						if (direction == 4) {
								anim.SetBool ("Right", true);
								anim.SetBool ("Left", false);
								anim.SetBool ("Up", false);
								anim.SetBool ("Down", false);
						
						}
				
				}******************************************************************************************/ 
		}

		IEnumerator wait (float time)
		{
				yield return new WaitForSeconds (time);
				yield break;
		}

		                     
}

