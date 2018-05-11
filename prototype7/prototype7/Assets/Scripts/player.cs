using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)){
			rb.velocity = new Vector2(-speed,0);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			rb.velocity = new Vector2(speed,0);
		}
		if (Input.GetKey(KeyCode.S)){
			rb.velocity = new Vector2(0,0);
		}
	}
}
