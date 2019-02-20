using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;



public static class Utility{
	static Utility(){
		Debug.Log("Hi");
		Random.InitState(System.DateTime.Now.GetHashCode());
	}

	public static int RandomRange(int min, int max){
		float fraction = Random.value;
		int rounded = (int)(100000 * fraction);
		int delta = max - min;
		int range = rounded % delta;

		return range + min;
	}
	private static float NoiseHelper(float nx, float ny, int octaves = 1, float freq = 1, float exp = 1, float scale = 1){
		//octaves = smoothness, 1 for smoothest
    	//frequency = zoom, 1 for most zoom
    	//exp = depth
		float e = 0;
		float amp = 1;
		List<float> amplitudes = new List<float>();
		//Debug.Log(amp);
		for (int i = 0; i < octaves; i++){
		    e += scale * amp * (Mathf.PerlinNoise(freq * nx, freq * ny));
		    amplitudes.Add(amp);
		    amp /= 2.0f;
		    freq *= 2.0f;
		}

		return Mathf.Pow((e/amplitudes.Sum()), exp);

	}

	public static float[,] NoiseMap(int size, float exp = 1, float freq = 1, int octaves = 1, float amp = 1,int offsetx = 0, int offsety = 0){
        float[,] noise = new float[size,size];
		for(int x = 0; x < size; x++){
			for(int y = 0; y < size; y++){
				float nx = offsetx + (float)x/size;
		   		float ny = offsety + (float)y/size;
				noise[x,y] = NoiseHelper(nx, ny, octaves, freq, exp, amp);

			}
		}
        return noise;
    }




}
