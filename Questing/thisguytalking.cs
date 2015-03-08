using UnityEngine;
using System.Collections;

public class thisguytalking : MonoBehaviour {

	private int goSeeDilen = 0, whyHaventYouSeenDilen = 1, youSawDilen = 2;
	private float temp;
	private bool lastSpeech, recentlyTalkedTo;
	private GameObject player, talking;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - temp > 0.5f) {
			lastSpeech = GetComponent<TalkingToPlayer>().speech;
			temp = Time.time;
		}

		if (GetComponent<TalkingToPlayer> ().speech == false && lastSpeech == true) {
			recentlyTalkedTo = true;		
		}

		// Quest 1
		if (recentlyTalkedTo) {

			if (player.GetComponent<Questing> ().guyToDilen == false) {
				GetComponent<TalkingToPlayer> ().saying = goSeeDilen;
				player.GetComponent<Questing> ().guyToDilen = true;
			} 
			else if (player.GetComponent<Questing> ().DilenToGuy == false) {
				GetComponent<TalkingToPlayer> ().saying = whyHaventYouSeenDilen;
						
			}
			else {
				GetComponent<TalkingToPlayer> ().saying = youSawDilen;

			}
		}
	}
}
