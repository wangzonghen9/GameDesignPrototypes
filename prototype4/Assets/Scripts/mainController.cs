using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mainController : MonoBehaviour {
	public GameObject chess;
	public GameObject black;
	public GameObject white;
	private int[,] chessState;
	public bool isWhite;
	private bool gameOver;
	public Transform[] locations;
	public Button but;
	public Text blackwin;
	public Text whitewin;
	public Text p1;
	public Text p2;
	public GameObject showblack;
	public GameObject showwhite;
	public int steps;

	//initialization
	void Start () {
		steps = 0;
		isWhite = true;
		gameOver = false;
		chess = white;
		chessState = new int[15, 20];
		but.gameObject.SetActive (false);
		blackwin.gameObject.SetActive (false);
		whitewin.gameObject.SetActive (false);
		p2.gameObject.SetActive (false);
		showblack.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	//take a step
	public void playChess(int no){
		if (!gameOver) {
			steps++;
			int row = makeAMove (no, isWhite);
			Quaternion v = new Quaternion(0,0,0,0);
			if (row != -1) {
				Instantiate (chess, locations [no].position, v);
				isWhite = !isWhite;
				swapChess ();
				checkWin (row, no, !isWhite);
			}
		}
	}

	//swap after every move
	private void swapChess(){
		if (chess == white) {
			chess = black;
			showblack.SetActive (true);
			showwhite.SetActive (false);
			p1.gameObject.SetActive (false);
			p2.gameObject.SetActive (true);
		} else {
			chess = white;
			showblack.SetActive (false);
			showwhite.SetActive (true);
			p2.gameObject.SetActive (false);
			p1.gameObject.SetActive (true);
		}
	}

	//tells the column, get the row
	private int makeAMove(int col, bool isWhite){
		for (int i = 14; i >= 0; i--) {
			if (chessState [i, col] == 0) {
				if (isWhite) {
					chessState [i, col] = 1;
				} else {
					chessState [i, col] = -1;
				}
				return i;
			}
		}
		return -1;
	}

	//check whether there is a winner
	private void checkWin(){
		//row
		for (int i = 14; i >= 0; i--) {
			int cur = 1;
			int count = 0;
			for (int j = 0; j < 20; j++) {
				if (chessState [i, j] == cur) {
					count++;
				} else if (chessState [i, j] == 0) {
					count = 0;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;
					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
			}
		}
		/*
		for (int i = 0; i < 20; i++) {
			int cur = 1;
			int count = 0;
			for (int j = 14; j >= 0; j--) {
				if (chessState [j, i] == cur) {
					count++;
				} else if (chessState [i, j] == 0) {
					break;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;
					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
			}
		}*/
		//dia upright -> leftdown
		for (int i = 4; i < 14; i++) {
			int count = 0;
			int cur = 1;
			int j = i;
			while (j >= 0) {
				if (chessState [j, i - j] == cur) {
					count++;
				} else if (chessState [j, i - j] == 0) {
					count = 0;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;

					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
				j--;
			}
		}
		for (int i = 0; i <= 15; i++) {
			int count = 0;
			int cur = 1;
			int k = 14;
			int j = i;
			while (k >= 0 && j < 20) {
				if (chessState [k, j] == cur) {
					count++;
				} else if (chessState [k, j] == 0) {
					count = 0;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;

					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
				k--;
				j++;
			}
		}
		//dia upleft -> rightdown
		for (int i = 4; i < 20; i++) {
			int count = 0;
			int cur = 1;
			int j = i;
			int k = 14;
			while (j >= 0 && k >= 0) {
				if (chessState [k, j] == cur) {
					count++;
				} else if (chessState [k, j] == 0) {
					count = 0;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;
					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
				j--;
				k--;
			}
		}
		for (int i = 4; i < 15; i++) {
			int count = 0;
			int cur = 1;
			int k = 19;
			int j = i;
			while (k >= 0 && j >= 0) {
				if (chessState [j, k] == cur) {
					count++;
				} else if (chessState [j, k] == 0) {
					count = 0;
				} else {
					count = 1;
					if (cur == 1) {
						cur = -1;
					} else {
						cur = 1;

					}
				}
				if (count == 5) {
					gameOver = true;
					if (cur == 1) {
						winner (true);
					} else {
						winner (false);
					}
				}
				j--;
				k--;
			}
		}

	}


	//check whether there is a winner
	private void checkWin(int row, int col, bool isWhite){
		int che = -1;
		if (isWhite) {
			che = 1;
		}

		int rstart = 0;
		if (row - 4 > 0)
			rstart = row - 4;
		int rend = 14;
		if (row + 4 < 14)
			rend = row + 4;
		int cstart = 0;
		if (col - 4 > 0)
			cstart = col - 4;
		int cend = 19;
		if (col + 4 < 19)
			cend = col + 4;
		int count = 0;
		for (int i = rstart; i <= rend; i++) {
			if (chessState [i, col] == che) {
				count++;
			} else {
				count = 0;
			}
			if (count == 5) {
				gameOver = true;
				winner (isWhite);
			}
		}
		count = 0;
		for (int i = cstart; i <= cend; i++) {
			if (chessState [row, i] == che) {
				count++;
			} else {
				count = 0;
			}
			if (count == 5) {
				Debug.Log ("win");
				gameOver = true;
				winner (isWhite);
			}
		}
		count = 0;
		for (int i = -4; i <= 4; i++) {
			if (row + i < 0 || col + i < 0)
				continue;
			if (row + i > 14 || col + i > 19)
				break;
			if (chessState [row + i, col + i] == che) {
				count++;
			} else {
				count = 0;
			}
			if (count == 5) {
				Debug.Log ("win");
				gameOver = true;
				winner (isWhite);
			}
		}
		count = 0;
		for (int i = -4; i <= 4; i++) {
			if (row + i > 14 || col - i < 0)
				break;
			if (row + i < 0 || col - i > 19)
				continue;
			if (chessState [row + i, col - i] == che) {
				count++;
			} else {
				count = 0;
			}
			if (count == 5) {
				Debug.Log ("win");
				gameOver = true;
				winner (isWhite);
			}
		}
	}


	//we get the winner!!
	private void winner(bool isWhite){
		but.gameObject.SetActive (true);
		if (isWhite) {
			whitewin.gameObject.SetActive (true);
		} else {
			blackwin.gameObject.SetActive (true);
		}
	}

	//remove all chess, for reverse
	public void removeCurrentChess(){
		for (int i = 0; i < steps; i++) {
			DestroyImmediate (GameObject.Find ("white(Clone)")); 
			DestroyImmediate (GameObject.Find ("black(Clone)")); 
		}
	}

	//reverse
	public void reverseTheBoard(){

		removeCurrentChess ();
		int[,] reverseChessState = new int[15, 20];
		for (int i = 0; i < 20; i++) {
			int j = 0;
			while (j < 15 && chessState [j, i] == 0)
				j++;
			
			for (int k = j; k < 15; k++) {
				reverseChessState [14 - k + j, i] = chessState [k, i];
			}
		}
		chessState = reverseChessState;

		Quaternion v = new Quaternion(0,0,0,0);
		for (int i = 14; i >= 0; i--) {
			for (int ii = 0; ii < 20; ii++) {
				Vector3 newl = new Vector3 ((float)locations [ii].position.x, (float)locations [ii].position.y - (float)(0.2 * i), (float)locations [ii].position.z);
				if (chessState [i, ii] == 1) {
					Instantiate (white, newl, v);
				}else if(chessState [i, ii] == -1){
					Instantiate (black, newl, v);
				}
			}
		}
		checkWin ();
	}

}
