using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Item: ScriptableObject{
	public String itemName;
	public Sprite sprite;
	public String description;
    public int amount = 1;
	public GameObject itemData;


}
