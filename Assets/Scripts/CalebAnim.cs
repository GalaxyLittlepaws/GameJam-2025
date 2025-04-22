using UnityEngine;

public class CalebAnim : MonoBehaviour {
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] InventoryObject bear;

    public void OpenInv() {
        inventoryManager.GetComponent<Animator>().SetTrigger("Open");
    }
    public void CloseInv() {
        inventoryManager.GetComponent<Animator>().SetTrigger("Close");
    }
    public void GrabBear() {
        inventoryManager.RemoveItem(bear);
    }

}
