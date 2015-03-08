using UnityEngine;
using System.Collections;

public class DilenTalking : MonoBehaviour {

	// Quest 1
	public int haventSeenYet = 0, goSeeGuy = 1; 
	private GameObject player;

	// General
	public int casual = 2;
	private bool recentlyTalkedTo, lastSpeech;
	private float temp;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		bool temp1, temp2, temp3;

		if (Time.time - temp > 0.5f) {
			lastSpeech = GetComponent<TalkingToPlayer>().speech;
			temp = Time.time;
		}

		if (GetComponent<TalkingToPlayer> ().speech == false && lastSpeech == true) {
			recentlyTalkedTo = true;		
		}

		if (player.GetComponent<Questing> ().guyToDilen) {
			GetComponent<TalkingToPlayer> ().saying = goSeeGuy;
		}

		// Quest 1
		if (recentlyTalkedTo) {

			if (player.GetComponent<Questing> ().guyToDilen == false && player.GetComponent<Questing> ().DilenToGuy == false) {
				GetComponent<TalkingToPlayer> ().saying = haventSeenYet;
			} 
			else if (player.GetComponent<Questing> ().guyToDilen) {
				GetComponent<TalkingToPlayer> ().saying = goSeeGuy;
				player.GetComponent<Questing> ().DilenToGuy = true;
						
			} 
			else {
				GetComponent<TalkingToPlayer> ().saying = casual;		
			}
		}
	}
}
