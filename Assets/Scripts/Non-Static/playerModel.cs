using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class playerModel : MonoBehaviour {

	public int speed = 10;
	public int visionRange = 25;
	public int visionWidth = 10;

	public int weaponRange = 5;
	public int weaponWidth = 10;


	//private Weapon equipedWeapon;

	private HitBox vision;
	private HitBox range;
	private HitBox reach;


	void Awake(){
		
		vision = transform.Find("Vision").GetComponent<HitBox>();
		vision.setType(typeof(Visible));
		range = transform.Find("Range").GetComponent<HitBox>();
		range.setType(typeof(Targetable));
		reach = transform.Find("Reach").GetComponent<HitBox>();
		reach.setType(typeof(Interactable));

	}


	void Update(){

	}




}
