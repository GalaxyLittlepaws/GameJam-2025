using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] List<InventoryObject> inventoryObjects;
    // -1 means no object is currently selected
    [SerializeField] int currentlySelected = -1;
    void Start() {
        
    }

    void Update() {
        
    }
}
