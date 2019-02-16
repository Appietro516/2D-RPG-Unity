using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
	[Header("Input")]
	[SerializeField]
	public string name;

	[SerializeField]
	private int val;

	[SerializeField]
	public int Val
	{
	   get { return getVal();}
	   set { val = value; }
   	}

	[SerializeField]
	public int max = -1;

	[SerializeField]
	public List<Modifier> modifiers = new List<Modifier>();

	public Stat(int val){
		this.val = val;
	}

	public Stat(string name = "", int val = 1, int max  = -1){
		this.name = name;
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
