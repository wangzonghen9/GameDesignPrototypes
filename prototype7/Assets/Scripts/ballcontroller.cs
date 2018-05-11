using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ballcontroller : MonoBehaviour {
	bool over;
	public Text gameOver;
	public Text levelCompleted;
	public Button restart;
	public Button toNextLevel;
	public GameObject whitehole;
	// Use this for initialization
	void Start () {
		gameOver.gameObject.SetActive (false);
		levelCompleted.gameObject.SetActive (false);
		restart.gameObject.SetActive (false);
		toNextLevel.gameObject.SetActive (false);
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "ground" && !over) {
			die ();
		}

		if (other.gameObject.tag == "player" && !over) {
			win ();
		}

		if (other.gameObject.tag == "blackhole" && !over) {
			gameObject.transform.position = whitehole.transform.position;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}

	}

	void die(){
		gameOver.gameObject.SetActive (true);
		restart.gameObject.SetActive (true);
		over = true;
	}

	void win(){
		levelCompleted.gameObject.SetActive (true);
		toNextLevel.gameObject.SetActive (true);
		over = true;
	}
}
