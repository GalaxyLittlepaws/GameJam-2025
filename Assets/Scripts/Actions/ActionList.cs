using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class ActionList : MonoBehaviour {
    
    public List<Action> actionList = new List<Action>();

    public void RunActionlist() {
        StartCoroutine(ActuallyRun());
    }
    IEnumerator ActuallyRun() {
        for (int i = 0; i < actionList.Count; i++) {
            if (actionList[i].index == 0) {
                yield return new WaitForSeconds(actionList[i].waitTime);
            } else if (actionList[i].index == 1) {
                SetVisibility(actionList[i].visiState, actionList[i].visiRenderer);
            } else if (actionList[i].index == 2) {
                Transform(actionList[i].transType, actionList[i].transObject, actionList[i].transNew, actionList[i].transTime);
                if (actionList[i].waitForTransform) {
                    yield return new WaitForSeconds(actionList[i].transTime);
                }
            } else if (actionList[i].index == 3) {
                Active(actionList[i].actObject, actionList[i].actState);
            } else if (actionList[i].index == 4) {
                ChangeHotspot(actionList[i].hotInteract, actionList[i].hotState);
            } else if (actionList[i].index == 5) {
                InteractableState(actionList[i].intState);
            } else if (actionList[i].index == 6) {
                if (actionList[i].animType == 0) {
                    Animate(actionList[i].animAnimator, actionList[i].animTrigger);
                } else if (actionList[i].animType == 1) {
                    Animate(actionList[i].animAnimator, actionList[i].animBool, actionList[i].animTrigger);
                } else if (actionList[i].animType == 2) {
                    Animate(actionList[i].animAnimator, actionList[i].animInt, actionList[i].animTrigger);
                }
            } else if (actionList[i].index == 7) {
                Debug.Log("End Game");
                EndGame();
            }
        }
        yield return new WaitForSeconds(0);
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
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #elif UNITY_STANDALONE 
        Application.Quit();
        #endif
    }

    public void ChangeHotspot(Interactable interactable, bool state) {
        interactable.canInteract = state;
    }

    /*
    Actions
    - Visibility x
    - Animate x
    - Fade sprite
    - Send Message
    - transform x
    - set active x
    - wait x
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
    - change hotspot x
    */
}
