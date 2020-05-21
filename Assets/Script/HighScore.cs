using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	Text ScoreTampil;


	// Use this for initialization
	void Start () {
		ScoreTampil = GetComponent<Text>();	
		ScoreTampil.text = PlayerPrefs.GetInt("KeyScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
