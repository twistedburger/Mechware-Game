using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	void Start () {
		target = GameObject.Find ("Player").transform; //Gets the reference for the "Player" object transform position
	}
	

	void Update () {
		transform.position = target.position + new Vector3 (0, 0, -10); //offset the z axis so that it doesnt overlap the player
	}
}
