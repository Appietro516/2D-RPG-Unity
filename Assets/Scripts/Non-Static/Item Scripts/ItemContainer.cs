using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class ItemContainer : MonoBehaviour{


	public List<Item> items =  new List <Item> ();

	//make a clone of the template in editor
    void OnValidate(){
		for (int i = 0; i < items.Count; i++){
            if(items[i] != null && !items[i].name.Contains("Clone")){
                items[i] = Instantiate(items[i]);
            }
        }
    }


    public void addItems(ItemContainer other){
        foreach(Item item1 in other.items){
            addItem(item1, item1.amount);
        }

        other.items = new List<Item>();

    }

    public void addItem(Item item1, int amt){
        foreach(Item item2 in this.items){
            if (item1.name == item2.name){
                item2.amount += amt;
                return;
            }
        }
        this.items.Add(item1);

    }

	public void cloneTemplate(Item item){
		item = Instantiate(item);
		addItem(item, item.amount);
	}






}
