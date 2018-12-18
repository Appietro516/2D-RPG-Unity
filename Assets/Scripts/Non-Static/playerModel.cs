using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class playerModel : MonoBehaviour {
	public Stats stats;

	//private Weapon equipedWeapon;

	public HitBox vision;
	public HitBox range;
	public HitBox reach;

	public List<Item> inventory =  new List <Item> ();

	void Awake(){
		stats = GetComponent<Stats>();

		vision = transform.Find("Vision").GetComponent<HitBox>();
		vision.setType(typeof(Visible));
		range = transform.Find("Range").GetComponent<HitBox>();
		range.setType(typeof(Targetable));
		reach = transform.Find("Reach").GetComponent<HitBox>();
		reach.setType(typeof(Interactable));

	}


	public void Move(float dx, float dy, int speed){
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Transform t = this.transform;

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
			rb.MovePosition(this.transform.position + dir);

			//face towards
			dir.Normalize();
		 	this.transform.right = dir;
		}

	}


	void Update(){

	}




}
