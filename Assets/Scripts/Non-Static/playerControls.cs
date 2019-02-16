using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Humanoid))]
public class playerControls : MonoBehaviour {

	private Humanoid model;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void Update(){
		//REMOVE THIS
		if (Camera.main.GetComponent<CameraFollow>().follow == null){
			Camera.main.GetComponent<CameraFollow>().follow = this.gameObject.transform;
		}


		if (Input.GetKeyDown("space")){
			if (model.reach.getNearest() != null){
				model.reach.getNearest().GetComponent<Interactable>().Interact(model);
			}
			else if (model.range.getNearest() != null){
				model.range.getNearest().GetComponent<Targetable>().RecieveAttack();
			}
		}
		if(Input.GetKeyDown("q")){
			SaveController.SaveScene();
			SaveController.SaveFile();
		}

		if(Input.GetKeyDown("e")){
			SaveController.LoadFile();
			SaveController.LoadScene();
		}



	}

	// Update is called once per frame
	void FixedUpdate () {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		model.Move(dx, dy, model.stats.getStatVal("Speed"));
	}

}
