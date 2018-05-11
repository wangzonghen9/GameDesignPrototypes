using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class environment : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restart(){
		SceneManager.LoadScene("level1");
	}

	public void toNext(){
		SceneManager.LoadScene("level2");
	}
}
