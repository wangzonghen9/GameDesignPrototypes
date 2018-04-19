using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyController : MonoBehaviour {
	public float destroyTime = 2f;
	public float rotateSpeed = 200f;
	public float moveSpeed = 10f;
	public Rigidbody2D enemy;
	public GameObject player;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
		enemy = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("player");
		float x = player.transform.position.x - enemy.transform.position.x;
		float y = player.transform.position.y - enemy.transform.position.y;
		float x2 = Mathf.Pow (x, 2);
		float y2 = Mathf.Pow (y, 2);
		float z = Mathf.Sqrt (x2 + y2);
		x = x / z;
		y = y / z;
		enemy.velocity = new Vector2(x * moveSpeed , y * moveSpeed);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemy.MoveRotation(enemy.rotation + rotateSpeed * Time.fixedDeltaTime);

	}
}
