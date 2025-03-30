using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ActionList : MonoBehaviour {


    void Start() {
        
    }

    void Update() {
        
    }

    public void SetVisibility(bool visible, SpriteRenderer sprite) {
        sprite.enabled = visible;
    }

    public void Animate(Animator animator, string trigger) {
        // trigger
        animator.SetTrigger(trigger);
    }
    public void Animate(Animator animator, int triggerInt, string trigger) {
        // int
        animator.SetInteger(trigger, triggerInt);
    }
    public void Animate(Animator animator, bool triggerBool, string trigger) {
        // bool
        animator.SetBool(trigger, triggerBool);;
    }

    public void Transform(int type, GameObject transformObject, Vector3 newTransform, float time) {
        // 0 = translate
        // 1 = rotate
        // 2 = scale
        if (type == 0) {
            transformObject.transform.DOMove(newTransform, time);
        } else if (type == 1) {
            transformObject.transform.DORotate(newTransform, time);
        } else if (type == 2) {
            transformObject.transform.DOScale(newTransform, time);
        }
    }

    public void Active(GameObject gameObject, bool state) {
        gameObject.SetActive(state);
    }

    public void InteractableState(bool state) {
        FindAnyObjectByType<GameManager>().interactionEnabled = state;
    }

    public void EndGame() {
        Application.Quit();
    }

    /*
    Actions
    - Visibility x
    - Animate x
    - Fade
    - Send Message
    - transform x
    - set active x
    - wait
    - fade camera
    - alter interaction state x
    - change camera
    - end game x
    - save
    - load
    - add inventory
    - remove inventory
    - play sound
    - play music
    - check variable
    - set variable
    - change hotspot
    */
}
