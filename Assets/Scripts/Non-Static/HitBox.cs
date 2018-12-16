using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour{
	public int width;
	public int height;

	public List <GameObject> lis = new List <GameObject> ();

	[SerializeField()]
	public Type type;

	private Collider2D box;



	void Awake(){
		box = GetComponent<Collider2D>();
		setRange(height, width);
	}

	void setRange(int y, int x){
		if (box != null){
			box.transform.localScale = new Vector3(x, y, 1);
		}
	}


	void OnTriggerEnter2D (Collider2D col) {
		addItem(col, box, lis);
	}

	void OnTriggerExit2D (Collider2D col) {
		lis.Remove(col.gameObject);
		print("removed obj");
	}

	private bool colSource(Collider2D source, Collider2D col){
		return source != null && source.IsTouching(col);
	}

	private void addItem(Collider2D col, Collider2D source, List <GameObject> lis){
		if (colSource(source, col) && col.gameObject.GetComponent<AbstractInteractable>() != null) {
			if (col.gameObject.GetComponent<AbstractInteractable>().GetType().GetInterfaces().Contains(type)){
				if(!(lis.Contains(col.gameObject))){
					lis.Add(col.gameObject);
					Debug.Log("Added Object");
				} else{
					Debug.Log("Already in targets");
				}
			}

		}

	}

	public void setType(Type t){
		this.type = t;
	}


}
