using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour {
	public Renderer rend;
	public float exp = 1;
	public float freq = 1;
	public int octaves = 1;
	public float scale = 1;
	public bool random = true;
	private int randomfactx = 0;
	private int randomfacty = 0;

	public Tilemap seatiles;
	public Tilemap landtiles;
	public Tile sea;
	public Tile land;

	public int chunk_x = 0;
	public int chunk_y = 0;
	public int size = 50000;
	public int chunk_size = 2;
	private byte[,] loaded;
	public float[,] noise;

	public GameObject player;

	public Tile coast_left;
	public Tile coast_right;
	public Tile coast_top;
	public Tile coast_bot;

	public Tile coast_top_left;
	public Tile coast_top_right;
	public Tile coast_bot_left;
	public Tile coast_bot_right;

	// Use this for initialization
	public void generate () {
		loaded = new byte[size/chunk_size, size/chunk_size];
		//help
		string str = "";
		if (random){
			randomfactx = Utility.RandomRange(0,10000);
			randomfacty = Utility.RandomRange(0,10000);
		}

		noise = Utility.NoiseMap(size, exp, freq, octaves, scale, randomfactx, randomfacty);

		Texture2D noiseTex;
		Color[] pix;

		noiseTex = new Texture2D(size, size);
		pix = new Color[noiseTex.width * noiseTex.height];

		for (int y = 0; y < size; y++){
			for (int x = 0; x < size; x++){
				float sample = noise[y,x];
				if (sample < .5){
					pix[y*size+x] = new Color(0, 0, 1);				}
				else{
					pix[y*size+x] = new Color(0, 1, 0);

					try{
						// if(noise[y+1, x] < .5){ //if top tile is sea
						// 	tiles.SetTile(new Vector3Int(x,y,0),coast_bot);
						// }
						// // else if(noise[y+1, x] >= .5 && noise[y+1, x-1] < .5 && noise[y, x-1] >= .5){
						// // 	tiles.SetTile(new Vector3Int(x,y,0),coast_bot_right);
						// // }
						// // else if(noise[y+1, x] < .5 && noise[y+1, x-1] >= .5 && noise[y, x-1] < .5){
						// // 	tiles.SetTile(new Vector3Int(x,y,0),coast_top_left);
						// // }
						// // else if(noise[y+1, x] < .5 && noise[y+1, x-1] < .5 && noise[y, x-1] >= .5){
						// // 	tiles.SetTile(new Vector3Int(x,y,0),coast_bot_left);
						// // }
						// // else if(noise[y+1, x] >= .5 && noise[y+1, x-1] >= .5 && noise[y, x-1] < .5){
						// // 	tiles.SetTile(new Vector3Int(x,y,0),coast_top_right);
						// // }
						// else if(noise[y-1, x] < .5){ //if top tile is sea
						// 	tiles.SetTile(new Vector3Int(x,y,0),coast_top);
						// }
						// else if(noise[y, x+1] < .5){ //if top tile is sea
						// 	tiles.SetTile(new Vector3Int(x,y,0),coast_left);
						// }
						// else if(noise[y, x-1] < .5){ //if top tile is sea
						// 	tiles.SetTile(new Vector3Int(x,y,0),coast_right);
						// }
						// else{
						// 	tiles.SetTile(new Vector3Int(x,y,0), land);
						// }
					}
					catch(IndexOutOfRangeException e){
						// tiles.SetTile(new Vector3Int(x,y,0), land);
					}

				}

				//str += ("" + noise[x,y] + ", ");
			}
			//str += "\n";
		}
		//print(str);
		noiseTex.SetPixels(pix);
		noiseTex.Apply();

		rend.material.mainTexture = noiseTex;
		int px = Utility.RandomRange(0, size);
		int py = Utility.RandomRange(0, size);
		while(noise[py,px] < .5){
			px = Utility.RandomRange(0, size);
			py = Utility.RandomRange(0, size);

		}
		player.transform.position = new Vector3(px,py,0);
	}

	public void RenderChunk(int cx, int cy){
		if (loaded[cx,cy] == 0){
			loaded[cx,cy] = 1;
			for (int y = chunk_size*cy; y < (chunk_size * cy) + chunk_size; y++){
				for (int x = chunk_size*cx; x < (chunk_size * cx) + chunk_size; x++){
					float sample = noise[y,x];
					if (sample < .5){
						seatiles.SetTile(new Vector3Int(x,y,0), sea);
					}
					else{
						landtiles.SetTile(new Vector3Int(x,y,0), land);
					}
				}
			}
		}

	}

	public IEnumerator LoadChunkAsync(int cx, int cy){
		for (int y = chunk_size*cy; y < (chunk_size * cy) + chunk_size; y++){
			for (int x = chunk_size*cx; x < (chunk_size * cx) + chunk_size; x++){
				float sample = noise[y,x];
				if (sample < .5){
					seatiles.SetTile(new Vector3Int(x,y,0), sea);
				}
				else{
					landtiles.SetTile(new Vector3Int(x,y,0), land);
				}
			}
			yield return null;
		}
	}

	public IEnumerator UnloadChunkAsync(int cx, int cy){
		for (int y = chunk_size*cy; y < (chunk_size * cy) + chunk_size; y++){
			for (int x = chunk_size*cx; x < (chunk_size * cx) + chunk_size; x++){
				float sample = noise[y,x];
				seatiles.SetTile(new Vector3Int(x,y,0), null);
				landtiles.SetTile(new Vector3Int(x,y,0), null);
			}
			yield return null;
		}
	}

	void Awake(){
		generate();
	}

	void Update(){
		chunk_x = (int)(player.transform.position.x / chunk_size);
		chunk_y = (int)(player.transform.position.y / chunk_size);
		//print(String.Format("X: {0}, y: {1}",chunk_x, chunk_y));
		if (noise != null){
			for(int i = 0; i < size/chunk_size; i++){
				for(int j = 0; j < size/chunk_size; j++){
					if(i >= chunk_x - 1 && i <= chunk_x + 1 && j >= chunk_y - 1 && j <= chunk_y + 1){
						if (loaded[i,j] == 0){
							StartCoroutine(LoadChunkAsync(i, j));
							loaded[i,j] = 1;
						}
					}
					else{
						if (loaded[i,j] == 1){
							StartCoroutine(UnloadChunkAsync(i, j));
							loaded[i,j] = 0;
						}
					}
				}
			}
		}
	}

}
