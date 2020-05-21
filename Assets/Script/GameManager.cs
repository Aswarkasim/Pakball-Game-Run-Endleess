using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//inisialisasi coin
	public int spawnTime, spawnCoin, Nilaiscore;

	//inisialisasi timerCoin
	private int timer, timerCoin;

	// SCORE
	Text Score, ScoreAkhir, HighScore;

	public GameObject panelOver;

	private AudioSource suaraCoin;
	public AudioClip mainkanSuara, mainkanTabrak;

	// Use this for initialization
	void Start () {
		
		BuatMusuh();
		BuatCoin();
		Score = GameObject.Find("score").GetComponent<Text>();
		Nilaiscore = 0;
		suaraCoin = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		timerCoin++;

		if(timer >= spawnTime){
			BuatMusuh();
			timer = 0;
		}

		if(timerCoin >= spawnCoin){
			BuatCoin();
			timerCoin = 0;
		}

		// Set score
		Score.text = "SCORE : "+Nilaiscore.ToString();
		
	}

	void BuatMusuh(){
		Instantiate(Resources.Load("Musuh"));
	}

	void BuatCoin(){
		Instantiate(Resources.Load("Coin"));
	}

	public void gameOver(){
		// Muncukna panel over
		panelOver.SetActive(true);
		// Inisialisasi ui 
		ScoreAkhir = GameObject.Find("ScoreAkhir").GetComponent<Text>();
		HighScore = GameObject.Find("HighScore").GetComponent<Text>();

		ScoreAkhir.text = Nilaiscore.ToString();


		if(Nilaiscore >= PlayerPrefs.GetInt("KeyScore")){
			PlayerPrefs.SetInt("KeyScore", Nilaiscore);
		}

		HighScore.text = "High Score : "+PlayerPrefs.GetInt("KeyScore").ToString();


	}

	public void restrat(){
		panelOver.SetActive(false);
		Application.LoadLevel(Application.loadedLevel);
	}

	public void coinTabrak(){
		suaraCoin.clip = mainkanSuara;
		suaraCoin.Play();
	}

	public void tabrakMusuh(){
		suaraCoin.clip = mainkanTabrak;
		suaraCoin.Play();
	}

	
}
