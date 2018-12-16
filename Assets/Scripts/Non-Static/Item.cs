using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour,Interactable{

	public String ItemName;
	public String description;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Interact(playerModel model){
		//TODO: this does not work.
		model.inventory.Add(this.gameObject);
		Destroy(this.gameObject);

	}

}
