using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Humanoid))]
public class playerControls : MonoBehaviour {

	private Humanoid model;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void Update(){
		if (Input.GetKeyDown("space")){
			if (model.reach.getNearest() != null){
				model.reach.getNearest().GetComponent<Interactable>().Interact(model);
			}
			if (model.range.getNearest() != null){
				model.range.getNearest().GetComponent<Targetable>().RecieveAttack();
			}
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		model.Move(dx, dy, model.stats.getStatVal("Speed"));
	}

}
