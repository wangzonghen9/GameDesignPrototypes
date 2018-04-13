using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public Text hammerText;
	public bool holdHammer;
	public int hammerNum;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		hammerText = GameObject.Find("Canvas/numHammer").GetComponent<Text>();
		holdHammer = false;
		hammerText.text = "Hammer: " + hammerNum.ToString();
	}

	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)){
			float tempz = rb.velocity.z / 2;
			rb.velocity = new Vector3(-speed,0, tempz);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			float tempz = rb.velocity.z / 2;
			rb.velocity = new Vector3(speed,0, tempz);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			float tempx = rb.velocity.x / 2;
			rb.velocity = new Vector3(tempx,0, speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			float tempx = rb.velocity.x / 2;
			rb.velocity = new Vector3(tempx,0, -speed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (hammerNum > 0 && !holdHammer) {
				holdHammer = true;
				hammerNum--;
				hammerText.text = "Hammer: " + hammerNum.ToString();
			}
		}
	}


	void OnCollisionStay(Collision other) {
		if (other.gameObject.CompareTag ("Target")){
			SceneManager.LoadScene("successScene");
		}

		if (other.gameObject.CompareTag ("Door")) {
			other.gameObject.SetActive (false);
		}

		if (holdHammer && !other.gameObject.CompareTag ("Ground")) {
			other.gameObject.SetActive (false);
			holdHammer = false;
		}
	}

}
