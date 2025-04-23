using UnityEngine;

public class CalebAnim : MonoBehaviour {
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] InventoryObject bear;
    [SerializeField] Animator invAnim;
    [SerializeField] AudioManager audioMan;

    public void OpenInv() {
        invAnim.GetComponent<Animator>().SetTrigger("Open");
        audioMan.Play();
    }
    public void CloseInv() {
        invAnim.GetComponent<Animator>().SetTrigger("Close");
        audioMan.Play();
    }
    public void GrabBear() {
        inventoryManager.RemoveItem(bear);
        FindAnyObjectByType<GameManager>().bearPuzzleDone = true;
    }

}
