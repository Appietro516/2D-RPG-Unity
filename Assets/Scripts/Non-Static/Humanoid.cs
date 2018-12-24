using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(ItemContainer))]
public class Humanoid : MonoBehaviour, Targetable, Visible {
	public Stats stats;
	public ItemContainer inventory;

	//private Weapon equipedWeapon;

	public HitBox vision;
	public HitBox range;
	public HitBox reach;
	Rigidbody2D rb;
	Transform t;

	void Awake(){
		t = this.transform;
		rb = GetComponent<Rigidbody2D>();
		stats = GetComponent<Stats>();
		inventory = GetComponent<ItemContainer>();

		vision = transform.Find("Vision").GetComponent<HitBox>();
		vision.setType(typeof(Visible));
		range = transform.Find("Range").GetComponent<HitBox>();
		range.setType(typeof(Targetable));
		reach = transform.Find("Reach").GetComponent<HitBox>();
		reach.setType(typeof(Interactable));

	}


	public void Move(float dx, float dy, int speed){
        if(Math.Abs(dx) >= 1 || Math.Abs(dy) >= 1){
			
			if (Math.Abs(dx) >= 1){
				dx = Math.Sign(dx);
			} else{
				dx = 0;
			}

			if (Math.Abs(dy) >= 1){
				dy = Math.Sign(dy);
			} else{
				dy = 0;
			}

			Vector3 dir;
			if(Math.Abs(dx) >= 1 && Math.Abs(dy) >= 1){
				float pos_x = (float)(Math.Sign(dx)*Math.Sqrt(1f/2f));
				float pos_y = (float)(Math.Sign(dy)*Math.Sqrt(1f/2f));
				dir = new Vector3(pos_x, pos_y,0) * Time.deltaTime * speed;
			} else{
				dir = new Vector3(Math.Sign(dx),Math.Sign(dy),0) * Time.deltaTime * speed;
			}
			print(dir);
			//RB moveposition produced lag
			//t.position += dir;
			rb.MovePosition(this.transform.position + dir);

			//face towards
			lookAt(dir);
		}

	}

	public void lookAt(Vector3 dir){

		dir.Normalize();
		this.transform.right = dir;
	}


	void Update(){
		if(stats.getStatVal("Health") <= 0){
			//teardown();
			Destroy(this.gameObject);
		}

	}

	public void RecieveAttack(){
		this.stats.deltaStatVal("Health", -20);
	}




}
