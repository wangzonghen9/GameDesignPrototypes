using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGameButton : MonoBehaviour {

	public void restartButton(){
		SceneManager.LoadScene("prototype#2");
	}
}
