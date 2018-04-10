using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public GameObject player;
	// Use this for initialization

	void Update(){
		transform.position = new Vector3(player.transform.position.x, -1, -10);
	}
}

