using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class environment2 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartgame(){
		SceneManager.LoadScene("level2");
	}

	public void toNextLevel(){
		SceneManager.LoadScene("level3");
	}


}
