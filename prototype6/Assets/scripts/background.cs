using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (player.transform.position.x + 8, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
