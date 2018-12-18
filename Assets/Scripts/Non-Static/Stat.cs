using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stat {
	private int val;

	public int Val
	{
	   get { return getVal();}
	   set { val = value; }
   	}

	private int max = -1;

	private List<Modifier> modifiers = new List<Modifier>();

	public Stat(int val){
		this.val = val;
	}

	public Stat(int val, int max){
		this.val = val;
		this.max = max;

	}

	public int getVal(){

		int bas = this.val;
		if (modifiers.Count >= 1){
			for(int i = 0; i < modifiers.Count; i++){
				Modifier m = modifiers[i];

				if(!m.IsExpired()){
					bas = m.Modify(bas);
				}
				else{
					RemoveModifier(m);
					i--;
				}
			}
		}

		return bas;
	}

	public int getRawVal(){
		return val;
	}

	public void setRawVal(int n){
		this.val = n;
	}

	public int getMax(){
		return max;
	}

	public void setMax(int n){
		this.max = n;
	}

	public void AddModifier(Modifier m){
		modifiers.Add(m);
	}

	public void RemoveModifier(Modifier m){
		modifiers.Remove(m);
	}

}
