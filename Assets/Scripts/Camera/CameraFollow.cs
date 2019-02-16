using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform follow;
	private Transform cam;

	void Awake(){
		//Application.targetFrameRate = 60;
		cam = Camera.main.transform;
	}
	void Update(){
		if (follow != null)
			cam.position = new Vector3(follow.position.x, follow.position.y, cam.position.z);

	}

}
