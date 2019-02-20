using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

[System.Serializable]
public class InteractableContainer : MonoBehaviour, Interactable, Visible, ISavable{
    public ItemContainer e;
    public void Interact(Humanoid model){
        model.inventory.addItems(e);
        Destroy(this.gameObject);

    }

    public string getPrefab(){
        return "Chest";
    }




}
