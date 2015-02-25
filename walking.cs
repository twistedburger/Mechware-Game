using UnityEngine;
using System.Collections;

public class walking : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 10; 
	

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector3 (speed, 0, 0));
	}
}
