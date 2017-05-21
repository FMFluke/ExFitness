using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	Vector3 pos;
	float speed = 2.0f;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) && transform.position == pos) { //Left arrow
			pos += Vector3.left;
		}
		if (Input.GetKey (KeyCode.RightArrow) && transform.position == pos) { //Right arrow
			pos += Vector3.right;
		}
		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
	}

}
