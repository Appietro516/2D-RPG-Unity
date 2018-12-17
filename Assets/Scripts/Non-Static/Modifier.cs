using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier {
	private Stat stat = null;
	private int duration = -1;
	private int magnitude;

	public delegate int Operation(int stat, int modifer);
	public Operation statfx;

	private float initTime;

	public Modifier(int magnitude, Operation statfx, int duration = -1){
		initTime = Time.time;
		this.statfx = statfx;
		this.duration = duration;
		this.magnitude = magnitude;
	}

	public void Init (Stat stat) {
		this.stat = stat;
	}

	public int Modify (int curr) {
		return statfx(curr, magnitude);
	}

	public bool IsExpired() {
		if (duration != -1){
			return (initTime + duration > Time.time);
		}
		else{
			return false;
		}

	}

	public static int Multiply(int a, int b){
		return a*b;
	}




}
