using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(playerModel))]
public class playerControls : MonoBehaviour {

	private playerModel model;

	void Awake(){
		model = GetComponent<playerModel>();
	}

	void Update(){

	}

	// Update is called once per frame
	void FixedUpdate () {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		Controller.Move(dx, dy, model.speed, this.gameObject);
	}

}
