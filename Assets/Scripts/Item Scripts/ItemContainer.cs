using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

[System.Serializable]
[ExecuteInEditMode]
public class ItemContainer{


	public List<Item> items =  new List <Item> ();



    public void addItems(ItemContainer other){
        foreach(Item item1 in other.items){
			if(item1 != null){
            	addItem(item1, item1.amount);
			}
        }

        other.items = new List<Item>();

    }

    public void addItem(Item item1, int amt){
		if(items.Count > 0){
	        foreach(Item item2 in this.items){
	            if (item1.itemName == item2.itemName){
	                item2.amount += amt;
	                return;
	            }
	        }
		}
        this.items.Add(item1);

    }

	public void cloneTemplate(Item item){
		item = Object.Instantiate(item);
		addItem(item, item.amount);

	}






}
