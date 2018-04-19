using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButton : MonoBehaviour {


	public void restartGame(){
		SceneManager.LoadScene("mainScene");
	}
}
