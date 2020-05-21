using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	//inisialisasi variabel
	public Vector3 spawnPoint;

	private Transform camPos;
	private int ranXPos;

	GameManager GameManager;

	// Use this for initialization
	void Start () {
		//posisi coin random
		ranXPos = Random.Range(-1, 2);
		//cloning coin
		transform.position = new Vector3(ranXPos, spawnPoint.y, spawnPoint.z);
		//melewati kamera
		camPos = GameObject.Find("Main Camera").GetComponent<Transform>();
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//memutar koin
		if(gameObject.name == "Coin"){
			transform.Rotate(0,0,3);
		}

		//jika coin melewati kamera
		transform.position += Vector3.back;

		if(transform.position.z < camPos.position.z){
			Destroy(gameObject);
			
		}

	}

	void OnTriggerEnter(Collider other){
		//jika player menabrak koin maka koin akan hilang'
		if(other.name == "Player"){
			GameManager.coinTabrak();
			Destroy(gameObject);
			GameManager.Nilaiscore += 10;
		}
	}
}
