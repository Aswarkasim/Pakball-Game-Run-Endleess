using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour {

	public int mundur, maju;

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.back * speed / 4;

		if(transform.position.z <= (-1 * mundur)){
			float i = transform.position.z;

			transform.position = new Vector3(transform.position.x,transform.position.y, (i+maju));
		}
	}
}
