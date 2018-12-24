using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class ItemContainer : MonoBehaviour{


	public List<ItemStack> items =  new List <ItemStack> ();


    public void addItems(ItemContainer other){
        foreach(ItemStack item1 in other.items){
            addItem(item1.item, item1.amount);
        }

        other.items = new List<ItemStack>();

    }

    public void addItem(Item item1, int amt){
        foreach(ItemStack item2 in this.items){
            if (item1.itemName == item2.item.itemName){
                item2.amount += amt;
                return;
            }
        }
        this.items.Add(new ItemStack(item1, amt));

    }




}
