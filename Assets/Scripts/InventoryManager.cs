using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
public class InventoryManager : MonoBehaviour {

    [SerializeField] List<InventoryObject> inventoryObjects = new List<InventoryObject>();
    [SerializeField] private int currentlySelected = -1;
    [SerializeField] List<Image>invUIElements;
    void Start() {
        DontDestroyOnLoad(this);
    }
    void Update() {
        for (int i = 0; i < invUIElements.Count; i++) {
            if (i < inventoryObjects.Count && inventoryObjects.Count != 0) {
                invUIElements[i].enabled = true;
                invUIElements[i].sprite = inventoryObjects[i].icon;
            } else {
                invUIElements[i].sprite = null;
                invUIElements[i].enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Deselct();
        }
    }
    public void SelectItem(int item) {
        if (item < inventoryObjects.Count) {
            if (currentlySelected != -1) {
                int i = 0;
                bool runIf = true;
                foreach(InventoryObject e in inventoryObjects[currentlySelected].canCombineWith) {
                    if (e == inventoryObjects[item] && runIf) {
                        InventoryObject newObject = inventoryObjects[currentlySelected].objectWhenCombined[i];
                        if (currentlySelected < item) {
                            inventoryObjects.RemoveAt(currentlySelected);
                            inventoryObjects.RemoveAt(item-1);
                        } else if (currentlySelected > item) {
                            inventoryObjects.RemoveAt(item);
                            inventoryObjects.RemoveAt(currentlySelected-1);
                        }
                        inventoryObjects.Add(newObject);
                        runIf = false;
                    }
                    i++;
                }
                Deselct();
            }
            currentlySelected = item;
            Cursor.SetCursor(inventoryObjects[item].cursor, new Vector2(0,0), CursorMode.Auto);
        }
        
    }
    public void Deselct() {
        currentlySelected = -1;
        Cursor.SetCursor(FindAnyObjectByType<GameManager>().cursor, new Vector2(0,0), CursorMode.Auto);
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