using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class playerModel : MonoBehaviour, Targetable {

	[Header("Stats")]
	public int speed = 10;

 	[Header("Ranges")]

	public int visionRange = 25;
	public int visionWidth = 10;
	public int weaponRange = 5;
	public int weaponWidth = 10;

	public int grabRadius = 10;


	//private Weapon equipedWeapon;

	private Collider2D range;
	private Collider2D vision;
	private Collider2D reach;


	List <GameObject> targets = new List <GameObject> ();
	List <GameObject> reachables = new List <GameObject> ();
	List <GameObject> visables = new List <GameObject> ();


	void Awake(){
		Transform v = transform.Find("Vision");
		if (v != null){
			vision = v.GetComponent<Collider2D>();
		}

		Transform ra =  transform.Find("Range");
		if (ra != null){
			range = ra.GetComponent<Collider2D>();
		}

		Transform re =  transform.Find("Reach");
		if (ra != null){
			reach = re.GetComponent<Collider2D>();
		}


		setRange(vision, visionRange, visionWidth);
		setRange(range, weaponRange, weaponWidth);
		setRange(reach, grabRadius, grabRadius);
	}

	void Update(){

	}

	void setRange(Collider2D hitbox, int rangeInt, int width){
		if (hitbox != null){
			hitbox.transform.localScale = new Vector3(width, rangeInt, 1);
		}
	}


	void OnTriggerEnter2D (Collider2D col) {
		if (colSource(range, col) && col.gameObject.GetComponent<Targetable>() != null) {
			if(!(targets.Contains(col.gameObject))){
				targets.Add(col.gameObject);
				Debug.Log("Added Object");
				print(targets);
			}
			else{
				Debug.Log("Already in targets");
			}

		}
		if (colSource(vision, col) && col.gameObject.GetComponent<Visible>() != null) {
			print("Can see object");
		}

		if (colSource(reach, col) && col.gameObject.GetComponent<Interactable>() != null) {
			print("Can grab object");
		}

	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.GetComponent<Targetable>() != null) {
			targets.Remove(col.gameObject);
		}
	}

	private bool colSource(Collider2D source, Collider2D col){
		return source != null && source.IsTouching(col);
	}


}
