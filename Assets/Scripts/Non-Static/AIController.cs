using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	private Humanoid model;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void Update(){
		if (model.vision.getNearest() != null){
			model.lookAt(model.vision.getNearest().transform.position);
		}

	}

}
