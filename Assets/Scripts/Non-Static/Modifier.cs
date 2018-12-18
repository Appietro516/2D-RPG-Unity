using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Modifier : ScriptableObject {

	public int duration = -1;
	public int magnitude;

	[System.Serializable]
 	public class effect : UnityEvent <int, int>{ }

	[SerializeField()]
	public effect statfx;

	private float initTime = -1;
	private int ret;



	public int Modify (int curr) {
		if (initTime == -1){
			initTime = Time.time;
		}
		statfx.Invoke(curr, magnitude);
		return ret;
	}

	public bool IsExpired() {
		if (duration != -1){
			return (initTime + duration <= Time.time);
		}
		else{
			return false;
		}

	}

	public void Multiply(int a, int b){
		this.ret = a*b;
	}

	public void Add(int a, int b){
		this.ret = a + b;
	}




}
