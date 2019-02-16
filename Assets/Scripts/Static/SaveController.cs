using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UEObject = UnityEngine.Object;
using System.IO;
using System;
using System.Reflection;


public static class SaveController{

	public static string save;


	// Use this for initialization
	public static void SaveScene () {
		List<string> scene = new List<string>();

		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach(GameObject go in allObjects){
			ISavable toSave = go.GetComponent<ISavable>();
			if (go.activeInHierarchy && go.transform.parent == null && toSave != null){
				string savedObject = SaveObj(toSave);
				scene.Add(savedObject);
			}
		}
		ListContainer<string> sceneCont = new ListContainer<string>();
		sceneCont.lis = scene;
		save = JsonUtility.ToJson(sceneCont);
		Debug.Log("SAVE:" + save);

	}

	// Use this for initialization
	public static void LoadScene () {
		Time.timeScale = 0;
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach(GameObject go in allObjects){
			ISavable toSave = go.GetComponent<ISavable>();
			if (go.activeInHierarchy && go.transform.parent == null && toSave != null){
				UEObject.Destroy(go);
			}
		}

		List<string> SceneObjs = JsonUtility.FromJson<ListContainer<string>>(save).lis;
		foreach(string goStr in SceneObjs){
			List<string> Objcomps = JsonUtility.FromJson<ListContainer<string>>(goStr).lis;
			GameObject go = UEObject.Instantiate(Resources.Load(Objcomps[0], typeof(GameObject))) as GameObject;
			LoadObj(go, goStr);
		}
		Time.timeScale = 1;



	}

	//NOT WORKING
	public static void SaveFile(){
		//Debug.Log(sceneDict);
		StreamWriter writer = new StreamWriter("MYSAVE", false);
		//Debug.Log(JsonUtility.ToJson(sceneDict));
		writer.Write(save);
		writer.Close();

	}

	public static void LoadFile(){
		StreamReader writer = new StreamReader("MYSAVE", true);
		save = writer.ReadToEnd();
		writer.Close();

	}

	public static string SaveObj(ISavable obj){
		Debug.Log(obj);
		FieldInfo[] prop = obj.GetType().GetFields();
		Array.Sort(prop, delegate(FieldInfo x, FieldInfo y) { return x.Name.CompareTo(y.Name); });

		List<string> comps = new List<string>();
		comps.Add(obj.getPrefab());
		string STransform = JsonUtility.ToJson(new STransform(((Component)obj).gameObject.transform));
		comps.Add(STransform);

		foreach (FieldInfo p in prop){
			//Debug.Log(p);
			if(null != p && !p.IsNotSerialized){
				Debug.Log(p);
				Type pType = p.FieldType;
				object pVal = p.GetValue(obj);
				pVal = Convert.ChangeType(pVal, pType);
				//Debug.Log(pVal);
				comps.Add(JsonUtility.ToJson(pVal));
			}
		}

		ListContainer<string> compsContainer = new ListContainer<string>();
		compsContainer.lis = comps;
		string retval = JsonUtility.ToJson(compsContainer);

		return retval;
	}

	public static void LoadObj(GameObject inst, string objStr){
		ISavable toLoad = inst.GetComponent<ISavable>();
		List<string> Objcomps = JsonUtility.FromJson<ListContainer<string>>(objStr).lis;
		Objcomps.RemoveAt(0);

		STransform temp = JsonUtility.FromJson<STransform>((string)Objcomps[0]);
		inst.transform.position = temp.position;
		inst.transform.rotation = temp.rotation;
		inst.transform.localScale = temp.scale;
		Objcomps.RemoveAt(0);



		FieldInfo[] prop = toLoad.GetType().GetFields();
		Array.Sort(prop, delegate(FieldInfo x, FieldInfo y) { return x.Name.CompareTo(y.Name); });


		foreach (FieldInfo p in prop){
			Debug.Log(p);
			if(null != p && !p.IsNotSerialized){
				Type pType = p.FieldType;

				object pVal = Activator.CreateInstance(pType);
				pVal = Convert.ChangeType(pVal, pType);
				Debug.Log(Objcomps[0]);
				JsonUtility.FromJsonOverwrite(Objcomps[0], pVal);

				p.SetValue(toLoad, pVal);
				Objcomps.RemoveAt(0);
			}
		}
	}



}
