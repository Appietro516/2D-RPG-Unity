using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat {
	private int val = 0;
	private int max = -1;

	private List<Modifier> modifiers;

	public Stat(int val){
		this.val = val;
	}

	public Stat(int val, int max){
		this.val = val;
		this.max = max;

	}

	public int getVal(){
		int base = val;
		foreach(Modifier m in modifiers){
			if(!m.isExpired()){
				base = m.modify(base);
			}
			else{
				RemoveModifier(m);
			}
		}

		return base;
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
		m.init(this);
		modifiers.Add(m);
	}

	public void RemoveModifier(Modifier m){
		modifiers.Remove(m);
	}

}
