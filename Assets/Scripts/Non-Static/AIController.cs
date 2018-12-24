using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour {

	private Humanoid model;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void FixedUpdate(){
		if (model.vision.getNearest() != null){
			Vector3 dir = model.vision.getNearest().transform.position - this.transform.position;
			//model.lookAt(dir);
			if(model.range.getNearest() == null){
				//print(dir);
				model.Move(dir.x,dir.y, model.stats.getStatVal("Speed"));

			}
		}

	}

}
