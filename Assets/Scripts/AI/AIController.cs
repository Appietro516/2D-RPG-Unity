using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	private Humanoid model;
	private Vector3 target = Vector3.zero;
	private Vector3 startpos;
	private int radius = 20;

	void Awake(){
		model = GetComponent<Humanoid>();
	}

	void FixedUpdate(){
		if (target == Vector3.zero){
			int x = Utility.RandomRange(-radius, radius);
			int y = Utility.RandomRange(-radius, radius);
			//print("X:" + x +",Y:" + y);

			float cordX = model.transform.position.x + x;
			float cordY = model.transform.position.y + y;
			Vector3 startpos = model.transform.position;

			target = new Vector3(cordX, cordY, 0);
		}
		else if(Vector3.Distance(model.transform.position, (startpos + target)) < 1){
			//print("HERE!");
			target = Vector3.zero;
		}
		else{
			//print(model.transform.position);
			model.MoveTo(target);
		}

		// GameObject v = model.vision.getNearest();
		// if (v != null){
		// 	if(v.GetComponent<Interactable>() != null && v.GetComponent<Visible>() != null){
		// 		model.MoveTo(v.gameObject.transform);
		// 	}
		// 	model.lookAt(v.transform.position);
		// }
		// GameObject i = model.reach.getNearest();
		// if(i != null){
		// 	i.GetComponent<Interactable>().Interact(this.model);
		// }

	}
	void Wander(){

	}

}
