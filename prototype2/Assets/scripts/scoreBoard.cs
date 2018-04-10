using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {


	public Text score;

	void Start(){
		score.text = (Timer.timeused).ToString();

	}

}
