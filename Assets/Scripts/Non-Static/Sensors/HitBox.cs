using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour{

	public List <GameObject> lis = new List <GameObject> ();

	[SerializeField()]
	public Type type;

	private Collider2D box;



	void Awake(){
		box = GetComponent<Collider2D>();
	}

	void setRange(int y, int x){
		if (box != null){
			box.transform.localScale = new Vector3(x, y, 1);
		}
	}


	void OnTriggerEnter2D (Collider2D col) {
		addItem(col);
	}

	void OnTriggerExit2D (Collider2D col) {
		if (isType((col.gameObject.GetComponent<AbstractInteractable>()))){
			lis.Remove(col.gameObject);
			print("removed obj");
		}
	}

	private void addItem(Collider2D col){
		if(isType(col.gameObject.GetComponent<AbstractInteractable>())){
			if(!(lis.Contains(col.gameObject))){
				lis.Add(col.gameObject);
				Debug.Log("Added Object");
			} else{
				Debug.Log("Already in targets");
			}

		}

	}

	public void setType(Type t){
		this.type = t;
	}

	public GameObject getNearest(){
		GameObject ret = null;
		float mindist = float.MaxValue;
		foreach(GameObject o in lis){
 			float dist = Vector3.Distance(o.transform.position, transform.parent.position);
			if(dist < mindist){
				mindist = dist;
				ret = o;
			}
		}
		return ret;
	}

	private bool isType(AbstractInteractable t){
		if (t != null) {
			if (t.GetType().GetInterfaces().Contains(type)){
				return true;
			}
		}
		return false;
	}




}
