using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

	public float myTimer = 50;
	public Text timerText;
	public GameObject player;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			timerUpdate ();
		}else{
			SceneManager.LoadScene("failScene");
		}
	}

	void timerUpdate() {
		if (myTimer <= Time.deltaTime) {
			timerText.text = "oops";
			gameOver = true;
		} else {
			myTimer -= Time.deltaTime;
			timerText.text = myTimer.ToString ("f1");
		}
	}
}
