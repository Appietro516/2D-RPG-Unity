using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableContainer : ItemContainer, Interactable {

    public void Interact(playerModel model){
        model.inventory.addItems(this);
        Destroy(this.gameObject);

    }




}
