using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeController : MonoBehaviour {
	public float destroyTime = 10f;
	public float moveSpeed = 2f;

	public Rigidbody2D heart;
	public GameObject player;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
		heart = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("player");

		float x = player.transform.position.x - heart.transform.position.x;
		float y = player.transform.position.y - heart.transform.position.y;
		float x2 = Mathf.Pow (x, 2);
		float y2 = Mathf.Pow (y, 2);
		float z = Mathf.Sqrt (x2 + y2);
		x = x / z;
		y = y / z;
		heart.velocity = new Vector2(x * moveSpeed , y * moveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
