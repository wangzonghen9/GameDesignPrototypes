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



	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //初始化sprite renderer 
		spriteRenderer.color = Color.white;
		starttime = Time.time;
	}



	void Update () {
		Timer.timeused = Time.time - starttime;
		timeText.text = Timer.timeused.ToString ();
		if (Input.GetKeyDown(KeyCode.Space)){
			jump ();
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

	void FixedUpdate(){
		onGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, whatIsGround);
		rb.velocity = new Vector2(movespeed, rb.velocity.y);
		if (transform.position.y < -8){
			die ();
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		if ((spriteRenderer.color == Color.white && other.gameObject.tag == "blackfloor") || (spriteRenderer.color == Color.black && other.gameObject.tag == "whitefloor")) {
			die ();
		}

		if (other.gameObject.tag == "hazard") {
			die ();
		}

		if (other.gameObject.tag == "end") {
			SceneManager.LoadScene("menu");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("circleIcon") && spriteRenderer.sprite == circle) {
			movespeed += 1;
		}
		if (other.gameObject.CompareTag ("squareIcon") && spriteRenderer.sprite == square) {
			movespeed += 1;
		}
	}




	void jump() {
		if (onGround) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpheight);
		}

	}

	void die(){
		SceneManager.LoadScene("prototype#2");
	}
}

