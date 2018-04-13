using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failButton : MonoBehaviour {

	public void ChangeScene(string scenename){
		SceneManager.LoadScene(scenename);
	}
}
