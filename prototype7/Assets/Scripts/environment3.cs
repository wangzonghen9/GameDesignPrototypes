using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class environment3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void tol1(){
		SceneManager.LoadScene("level1");
	}

	public void tol2(){
		SceneManager.LoadScene("level2");
	}

	public void tol3(){
		SceneManager.LoadScene("level3");
	}
}
