using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable: AbstractInteractable{
	void Interact(playerModel model); //return interactmessege?
}
