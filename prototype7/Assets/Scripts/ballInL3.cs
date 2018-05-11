using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballInL3 : MonoBehaviour {


	public GameObject[] redbrick;
	public GameObject[] yellowbrick;
	public GameObject[] purplebrick;

	bool over;
	public Text gameOver;
	public Text levelCompleted;
	public Button restart;
	public Button tol1;
	public Button tol2;
	public Button tol3;

	//for color
	private SpriteRenderer spriteRenderer;
	private int state = 1;
	private Color pur = new Vector4(0.584f,0.455f,0.949f,1);
	private Color red = new Vector4(1,0.384f,0.361f,1);
	private Color yel = new Vector4(1,1,0.094f,1);

	// Use this for initialization
	void Start () {
		gameOver.gameObject.SetActive (false);
		levelCompleted.gameObject.SetActive (false);
		restart.gameObject.SetActive (false);
		tol1.gameObject.SetActive (false);
		tol2.gameObject.SetActive (false);
		tol3.gameObject.SetActive (false);
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = pur;
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (state == 1) {
				spriteRenderer.color = red;
				state = 2;
			} else if (state == 2) {
				spriteRenderer.color = yel;
				state = 3;
			} else if (state == 3) {
				spriteRenderer.color = pur;
				state = 1;
			}
		}

		if (state == 1) {
			foreach (GameObject b in purplebrick) {
				b.transform.Rotate (new Vector3 (0, 0, -45) * Time.deltaTime);
			}
		} else if (state == 2) {
			foreach (GameObject b in redbrick) {
				b.transform.Rotate (new Vector3 (0, 0, -45) * Time.deltaTime);
			}
		} else {
			foreach (GameObject b in yellowbrick) {
				b.transform.Rotate (new Vector3 (0, 0, -45) * Time.deltaTime);
			}
		}
	}


	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "ground" && !over) {
			die ();
		}

		if (other.gameObject.tag == "player" && !over) {
			win ();
		}
	}

	void die(){
		gameOver.gameObject.SetActive (true);
		restart.gameObject.SetActive (true);
		over = true;
	}

	void win(){
		levelCompleted.gameObject.SetActive (true);
		tol1.gameObject.SetActive (true);
		tol2.gameObject.SetActive (true);
		tol3.gameObject.SetActive (true);
		over = true;
	}
}
