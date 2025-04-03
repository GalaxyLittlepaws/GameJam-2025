using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] List<InventoryObject> inventoryObjects = new List<InventoryObject>();
    [SerializeField] private int currentlySelected = -1;

    void Start() {
        
    }

    void Update() {
        // Handle inventory updates if needed
    }

    public void AddItem(InventoryObject item) {
        inventoryObjects.Add(item);
    }

    public void RemoveItem(InventoryObject item) {
        inventoryObjects.Remove(item);
    }

    public InventoryObject GetSelectedItem() {
        if (currentlySelected >= 0 && currentlySelected < inventoryObjects.Count) {
            return inventoryObjects[currentlySelected];
        }
        return null;
    }
}