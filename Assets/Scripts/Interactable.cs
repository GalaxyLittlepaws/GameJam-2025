using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {

    public bool canInteract = true;
    GameManager manager;
    [SerializeField] UnityEvent methodMouseEnter;
    [SerializeField] UnityEvent methodMouseExit;
    [SerializeField] UnityEvent methodMouseDown;

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
