using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerController : MonoBehaviour {
	public float movespeed;
	private Rigidbody2D player;
	private SpriteRenderer spriteRenderer;
	public GameObject enemy;
	public GameObject heart;
	public GameObject star;
	public Transform[] locations;
	public double spawnTime = 2;
	public double difficultyLevel = 1;
	public Text difficulty;
	public Text gameOver;
	public Text score;
	public Button restartButton;
	public int lives;
	public Sprite[] hearts;
	public Image heartUI;
	public bool invincible;


	private float starttime;
	private float invincibleTime;
	public Text timeText;

	void Start () {
		lives = 3;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		player = GetComponent<Rigidbody2D>();
		gameOver.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
		score.gameObject.SetActive (false);
		difficulty.text = "Difficulty Level: " + difficultyLevel.ToString ();
		InvokeRepeating ("spawnEnemy", (float)(spawnTime - (difficultyLevel * 0.07)), (float)(spawnTime - (difficultyLevel * 0.07)));
		updateLives ();
		starttime = Time.time;
		invincibleTime = 0;
		invincible = false;
	}

	void Update () {
		if (invincible && invincibleTime == 0) {
			invincibleTime = Time.time - starttime;
			spriteRenderer.color = Color.yellow;
		}else if(invincible && invincibleTime != 0 && (Time.time - starttime - invincibleTime > 4) && (Time.time - starttime - invincibleTime < 5)){
			spriteRenderer.color = Color.red;
		}else if(invincible && invincibleTime != 0 && (Time.time - starttime - invincibleTime > 5)){
			invincible = false;
			invincibleTime = 0;
			spriteRenderer.color = Color.white;
		}

		Timer.timeused = Time.time - starttime;
		timeText.text = Timer.timeused.ToString ();

		if (player.transform.position.x > 6 || player.transform.position.x < -6 || player.transform.position.y > 5 || player.transform.position.y < -5) {
			lives = 0;
			updateLives ();
			die ();
		}


		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (difficultyLevel == 1) {
				player.velocity = new Vector2(movespeed - 1, 0);
			} else {
				player.velocity = new Vector2(movespeed, 0);
			}
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (difficultyLevel == 1) {
				player.velocity = new Vector2(0, movespeed - 1);
			} else {
				player.velocity = new Vector2(0, movespeed);
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (difficultyLevel == 1) {
				player.velocity = new Vector2(-movespeed + 1, 0);
			} else {
				player.velocity = new Vector2(-movespeed, 0);
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (difficultyLevel == 1) {
				player.velocity = new Vector2(0, -movespeed + 1);
			} else {
				player.velocity = new Vector2(0, -movespeed);
			}
		}

		if (Input.GetKeyDown (KeyCode.X) && difficultyLevel < 5) {
			difficultyLevel++;
			changeDifficulty ();
		}
		if (Input.GetKeyDown (KeyCode.Z) && difficultyLevel > 1) {
			difficultyLevel--;
			changeDifficulty ();
		}
	}
		
	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "hazard") {
			if (invincible) {
				Destroy (other.gameObject);
			} else {
				lives--;
				Destroy(other.gameObject);
				updateLives ();
				if (lives == 0) {
					die ();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("heart") && lives < 5) {
			lives += 1;
			updateLives ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("star")) {
			Destroy (other.gameObject);
			invincible = true;
		}
	}

	private void spawnEnemy() {
		int sIndex = Random.Range (0, locations.Length);
		Instantiate (enemy, locations [sIndex].position, locations [sIndex].rotation);
	}

	private void spawnHeart() {
		int sIndex = Random.Range (0, locations.Length);
		Instantiate (heart, locations [sIndex].position, locations [sIndex].rotation);
	}

	private void spawnStar() {
		int sIndex = Random.Range (0, locations.Length);
		Instantiate (star, locations [sIndex].position, locations [sIndex].rotation);
	}

	private void die(){
		score.text = Timer.timeused.ToString () + " seconds";
		score.gameObject.SetActive (true);
		Destroy (gameObject);
		gameOver.gameObject.SetActive (true);
		restartButton.gameObject.SetActive (true);
	}

	private void changeDifficulty(){
		difficulty.text = "Difficulty Level: " + difficultyLevel.ToString ();
		CancelInvoke();
		InvokeRepeating ("spawnEnemy", (float)(spawnTime - (difficultyLevel * 0.07)), (float)(spawnTime - (difficultyLevel * 0.07)));
		if (difficultyLevel == 3) {
			InvokeRepeating ("spawnHeart", 4, 10);
		}
		if (difficultyLevel > 3) {
			InvokeRepeating ("spawnHeart", 2, 7);
		}
		if (difficultyLevel > 4) {
			InvokeRepeating ("spawnStar", 2, 13);
		}
	}

	private void updateLives(){
		heartUI.sprite = hearts [lives];
	}


}
