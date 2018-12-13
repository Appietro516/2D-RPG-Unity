using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Controller {

	public static void Move(float dx, float dy, int speed, GameObject obj){
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        Transform t = obj.transform;

        if(Math.Abs(dx) >= 1 || Math.Abs(dy) >= 1){
			Vector3 dir;
			if(Math.Abs(dx) >= 1 && Math.Abs(dy) >= 1){
				float pos_x = (float)(Math.Sign(dx)*Math.Sqrt(1f/2f));
				float pos_y = (float)(Math.Sign(dy)*Math.Sqrt(1f/2f));
				dir = new Vector3(pos_x, pos_y,0) * Time.deltaTime * speed;
			} else{
				dir = new Vector3(dx,dy,0) * Time.deltaTime * speed;
			}

			//move rb
			rb.MovePosition(obj.transform.position + dir);

			//face towards
			dir.Normalize();
		 	obj.transform.right = dir;
		}

	}

    public static void Attck(bool type, GameObject obj){
        
    }
}
