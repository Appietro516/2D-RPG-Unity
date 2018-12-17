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
		if (Input.GetKeyDown("space")){
			if (model.reach.getNearest() != null){
				model.reach.getNearest().GetComponent<Interactable>().Interact(model);
			}
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		model.Move(dx, dy, model.speed.getVal());
	}

}
