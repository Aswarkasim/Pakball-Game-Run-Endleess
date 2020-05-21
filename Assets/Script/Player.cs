using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	GameManager GameManager;
	// Use this for initialization

	Rigidbody rb;
	float dirX;
	
	void Start () {
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//mengambil Input sensor Smartphone
		dirX = Input.acceleration.x * 10;
		// Batas gerak player
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1, 1.5f), transform.position.y, transform.position.z);

		if((Input.GetKey(KeyCode.RightArrow) ) && transform.position.x <2){
			transform.position += Vector3.right/12;
		}

		if((Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -1){
			transform.position += Vector3.left/12;
		}
	}

	private void FixedUpdate(){
	// Gerakan player berdasarkan sensor android kecepatan
		//rb.AddForce(new Vector3(Mathf.Clamp(dirX, -2, 2), 0,0));
		rb.velocity = new Vector3(Mathf.Clamp(dirX, -10, 10), -2, 0);
		print(dirX);
	}

	

	void OnTriggerEnter(Collider other){
		//jika player menabrak musuh
		if(other.tag == "Musuh"){
			GameManager.tabrakMusuh();
			Destroy(gameObject);
			GameManager.gameOver();
		}

		
	}



	
}
