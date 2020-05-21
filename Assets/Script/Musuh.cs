using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh : MonoBehaviour {

	public Vector3 spawnPoint;

	private Transform camPos;
	private int ranXPos;

	GameManager GameManager;

	// inisialisasi kecepatan dan kondisi kesulitan game jika semakin lama
	public int speed =1, tambahBatas = 11;

    // batasan untuk menambah kesulitan game
	private int batas;




	// Use this for initialization
	void Start () {
		ranXPos = Random.Range(-1, 2);
		transform.position = new Vector3(ranXPos, spawnPoint.y, spawnPoint.z);
		camPos = GameObject.Find("Main Camera").GetComponent<Transform>();
		// Abbil script game manager
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//menambah kecepatan setiap mmenempuh point tertentu


		transform.position += Vector3.back*speed;
		print(GameManager.spawnTime);

		if(transform.position.z < camPos.position.z){
			Destroy(gameObject);
			GameManager.Nilaiscore++;
			// jika spawntime pada gamemanagermasih lebih dari 6
			if (GameManager.spawnTime > 6){
                // jika kondisi score bertambah banyak sesuai kondisi batas
				if (GameManager.Nilaiscore % 10 == 0){
                    // kurangi spawntime pada gameManager, agar wall yang dibuat lebih cepat
					GameManager.spawnTime -= 5;
                    // tambahkan batas kondisi untuk menambah kesulitan game
					//batas +=tambahBatas;
				}

                // jika score bertambah banyak lagi
				if (GameManager.Nilaiscore % 15 == 0){
                    // tambahkan kecepatan wall
					speed += 1;
                    // tambahkan batas kondisi untuk menambah kesulitan game
                   // batas += tambahBatas;
				}
			}


		}
	}
}
