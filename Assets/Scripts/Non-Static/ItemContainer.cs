using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemContainer : MonoBehaviour{


	public List<Item> items =  new List <Item> ();
    public Item test;


    public void addItems(ItemContainer other){
        foreach(Item item1 in other.items){
            addItem(item1, item1.amount);
        }

        other.items = new List<Item>();

    }

    public void addItem(Item item1, int amt){
        foreach(Item item2 in this.items){
            if (item1.ID == item2.ID){
                item2.amount += amt;
                return;
            }
        }
        this.items.Add(item1);

    }






}
