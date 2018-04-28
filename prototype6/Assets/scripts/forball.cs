using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forball : MonoBehaviour {
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		rb.velocity = new Vector2 (0, 10);
	}
}
