using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	private Humanoid model;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void FixedUpdate(){
		GameObject v = model.vision.getNearest();
		if (v != null){
			if(v.GetComponent<Interactable>() != null && v.GetComponent<Visible>() != null){
				model.MoveTo(v.gameObject.transform);
			}
			model.lookAt(v.transform.position);
		}
		GameObject i = model.reach.getNearest();
		if(i != null){
			i.GetComponent<Interactable>().Interact(this.model);
		}

	}

}
