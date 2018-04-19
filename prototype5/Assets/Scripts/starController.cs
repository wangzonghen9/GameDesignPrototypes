using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour {
	public float destroyTime = 8f;
	public float moveSpeed = 4f;

	public Rigidbody2D star;
	public GameObject player;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
		star = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("player");

		float x = player.transform.position.x - star.transform.position.x;
		float y = player.transform.position.y - star.transform.position.y;
		float x2 = Mathf.Pow (x, 2);
		float y2 = Mathf.Pow (y, 2);
		float z = Mathf.Sqrt (x2 + y2);
		x = x / z;
		y = y / z;
		star.velocity = new Vector2(x * moveSpeed , y * moveSpeed);
	}
}
