using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController1 : MonoBehaviour {

	public GameObject[] brick;
	bool flag;
	// Use this for initialization
	void Start () {
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (flag) {
			foreach (GameObject b in brick) {
				b.transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("player")) {
			flag = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("player")) {
			flag = false;
		}
	}
}
