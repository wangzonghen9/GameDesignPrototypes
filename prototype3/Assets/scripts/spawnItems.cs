using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItems : MonoBehaviour {
	public Transform[] spawnPoints;
	public GameObject player;
	public GameObject target;

	void Start () {
		spawn ();
	}
	


	void spawn(){
		int spawnIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (player, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
		spawnIndex = Random.Range (0, spawnPoints.Length);
		Quaternion v3 = spawnPoints [spawnIndex].rotation;
		v3.y = 90;
		Instantiate (target, spawnPoints[spawnIndex].position, v3);
	}
}
