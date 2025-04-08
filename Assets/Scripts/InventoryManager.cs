using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    [SerializeField] List<InventoryObject> inventoryObjects = new List<InventoryObject>();
    [SerializeField] private int currentlySelected = -1;
    [SerializeField] List<Image>invUIElements;
    void Start() {
        DontDestroyOnLoad(this);
    }
    void Update() {
        for (int i = 0; i < invUIElements.Count; i++) {
            if (i < inventoryObjects.Count) {
                invUIElements[i].enabled = true;
                invUIElements[i].sprite = inventoryObjects[i].icon;
            } else {
                invUIElements[i].sprite = null;
                invUIElements[i].enabled = false;
            }
        }
    }
    public void SelectItem(int item) {
        currentlySelected = item;
        Cursor.SetCursor(inventoryObjects[item].cursor, new Vector2(0,0), CursorMode.Auto);
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