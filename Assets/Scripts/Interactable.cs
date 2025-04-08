using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {

    public bool canInteract = true;
    GameManager manager;
    [Tooltip("Triggers when the mouse clicks element")]
    [SerializeField] UnityEvent methodMouseDown;

    [Tooltip("Triggers when the mouse hovers over element")]
    [SerializeField] UnityEvent methodMouseEnter;

    [Tooltip("Triggers when the mouse leaves element")]
    [SerializeField] UnityEvent methodMouseExit;


    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
        manager = FindFirstObjectByType<GameManager>();
    }


    void OnMouseEnter() {
        if (manager.interactionEnabled && methodMouseEnter != null && canInteract) {
            methodMouseEnter.Invoke();
            
        }
            
    }
    void OnMouseExit() {
        if (manager.interactionEnabled && methodMouseExit != null && canInteract) {
            methodMouseExit.Invoke();
        }
    }
    void OnMouseDown() {
        if (manager.interactionEnabled && methodMouseDown != null && canInteract) {
            methodMouseDown.Invoke();
            Debug.Log("I did it!");
        }
            
    }
}
