using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	public int health = 20, exp = 0, attackStrength = 5, attackModifier = 1;
	public string currentAbility;

	private float bbtime, pptime, sstime, sctime; //bigbonktime, paralyzingpoketime, superslamtime, spincycletime
	private float shortTime = 1, longTime = 10, medTime = 5;
	private bool specialReady = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
