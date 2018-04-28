using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {


	public Rigidbody2D rb;
	public float movespeed;
	public float jumpheight;
	public Transform start;

	//	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;

	private SpriteRenderer spriteRenderer;
	private Image image;
	public Sprite circle;
	public Sprite square;

	private float starttime;
	public Text timeText;
	public Text gameOver;
	public Button restartGame;
	private bool over;
	private bool notExplodedYet;
	private bool notIconYet;
	public GameObject explode;
	public GameObject blackblood;
	public GameObject whiteblood;
	public GameObject getIcon;

	public AudioSource jumpAudio;
	public AudioSource coinAudio;
	public AudioSource dieAudio;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //初始化sprite renderer 
		spriteRenderer.color = Color.white;
		starttime = Time.time;
		gameOver.gameObject.SetActive (false);
		restartGame.gameObject.SetActive (false);
		over = false;
		notExplodedYet = true;
		notIconYet = true;

	}



	void Update () {
		if (!over) {
			Timer.timeused = Time.time - starttime;
			timeText.text = Timer.timeused.ToString ("0.00");
			if (Input.GetKeyDown (KeyCode.Space)) {
				jump ();
				jumpAudio.Play ();
			}
			if (Input.GetKeyDown (KeyCode.Z)) {
				if (spriteRenderer.color == Color.white) {
					spriteRenderer.color = Color.black;
				} else {
					spriteRenderer.color = Color.white;
				}
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				if (spriteRenderer.sprite == circle) {
					spriteRenderer.sprite = square;
				} else {
					spriteRenderer.sprite = circle;
				}
			}
		}
	}

	void FixedUpdate(){
		if (!over) {
			onGround = Physics2D.OverlapCircle (transform.position, groundCheckRadius, whatIsGround);
			rb.velocity = new Vector2 (movespeed, rb.velocity.y);
			if (transform.position.y < -8) {
				die ();
			}
		} else {
			rb.velocity = new Vector2 (0, 0);
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		if ((spriteRenderer.color == Color.white && other.gameObject.tag == "blackfloor") || (spriteRenderer.color == Color.black && other.gameObject.tag == "whitefloor")) {
			if (notExplodedYet) {
				dieAudio.Play ();
				if (spriteRenderer.color == Color.white) {
					Instantiate (whiteblood, gameObject.transform.position, gameObject.transform.rotation);
				} else {
					Instantiate (blackblood, gameObject.transform.position, gameObject.transform.rotation);
				}
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 10);
				notExplodedYet = false;
			}
			die ();
		}

		if (other.gameObject.tag == "hazard") {
			if (notExplodedYet) {
				dieAudio.Play ();
				Instantiate (explode, gameObject.transform.position, gameObject.transform.rotation);
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 10);
				notExplodedYet = false;
			}
			die ();
		}

		if (other.gameObject.tag == "end") {
			SceneManager.LoadScene("menu");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("circleIcon") && spriteRenderer.sprite == circle) {
			coinAudio.Play ();
			//SpriteRenderer cir = other.gameObject.GetComponent<SpriteRenderer>();
			other.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0);
			other.gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
			if (notIconYet) {
				Instantiate (getIcon, other.gameObject.transform.position, other.gameObject.transform.rotation);
				notIconYet = false;
			}
			movespeed += 1;
		}
		if (other.gameObject.CompareTag ("squareIcon") && spriteRenderer.sprite == square) {
			coinAudio.Play ();
			other.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0);
			other.gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
			if (notIconYet) {
				Instantiate (getIcon, other.gameObject.transform.position, other.gameObject.transform.rotation);
				notIconYet = false;
			}
			movespeed += 1;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("circleIcon") && spriteRenderer.sprite == circle) {
			other.gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4 (0.67f, 0.62f, 0.69f, 1);
			notIconYet = true;
		}
		if (other.gameObject.CompareTag ("squareIcon") && spriteRenderer.sprite == square) {
			other.gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4 (0.67f, 0.62f, 0.69f, 1);
			notIconYet = true;
		}
	}




	void jump() {
		if (onGround) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpheight);
		}

	}

	void die(){
		gameOver.gameObject.SetActive (true);
		restartGame.gameObject.SetActive (true);

		over = true;
	}


}

