using UnityEngine;

[System.Serializable]
public class STransform{
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 scale;

    public STransform(Transform t){
		this.position = t.position;
	    this.rotation = t.rotation;
		this.scale = t.localScale;
    }

}
