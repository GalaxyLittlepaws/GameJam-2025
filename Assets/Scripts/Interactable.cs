using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {

    public bool canInteract = true;
    [SerializeField] bool whenInvHeld = false;
    [SerializeField] InventoryObject objcetToAccpet;
    GameManager manager;
    [Tooltip("Triggers when the mouse clicks element")]
    [SerializeField] UnityEvent methodMouseDown;


    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
        manager = FindFirstObjectByType<GameManager>();
    }
    void OnMouseDown() {
        if (whenInvHeld && FindAnyObjectByType<InventoryManager>().GetSelectedItem() != objcetToAccpet) {
            return;
        }
        if (manager.interactionEnabled && methodMouseDown != null && canInteract) {
            methodMouseDown.Invoke();
        }
            
    }
}
