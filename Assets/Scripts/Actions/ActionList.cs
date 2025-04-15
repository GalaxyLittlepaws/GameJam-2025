using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionList : MonoBehaviour {
    
    [HideInInspector] public List<Action> actionList = new List<Action>();
    [HideInInspector] public bool runOnStart = false;
    void Start() {
        if (runOnStart) {
            RunActionlist();
        }
    }

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
            } else if (actionList[i].index == 8) {
                AddInventoryObject(actionList[i].addInvObj);
            } else if (actionList[i].index == 9) {
                RemoveInventoryObject(actionList[i].remInvObj);
            } else if (actionList[i].index == 10) {
                if (CheckCurrentInventory(actionList[i].checkInvObj, actionList[i].checkSkipTo, actionList[i].checkSkipTrue)) {
                    yield break;
                }
            } else if (actionList[i].index == 11) {
                FadeCamera(actionList[i].camFadeAmount, actionList[i].camFadeTime);
            } else if (actionList[i].index == 12) {
                FadeSprite(actionList[i].spriteFadeAmount, actionList[i].spriteFadeTime, actionList[i].spriteFade);
            } else if (actionList[i].index == 13) {
                ChangeScene(actionList[i].useID, actionList[i].sceneID, actionList[i].sceneName);
            }
            if (actionList[i].comment != null && actionList[i].comment != "")
                Debug.Log(actionList[i].comment);
        }
    }

    void SetVisibility(bool visible, SpriteRenderer sprite) {
        sprite.enabled = visible;
    }

    void Animate(Animator animator, string trigger) {
        // trigger
        animator.SetTrigger(trigger);
    }
    void Animate(Animator animator, int triggerInt, string trigger) {
        // int
        animator.SetInteger(trigger, triggerInt);
    }
    void Animate(Animator animator, bool triggerBool, string trigger) {
        // bool
        animator.SetBool(trigger, triggerBool);;
    }

    void Transform(int type, GameObject transformObject, Vector3 newTransform, float time) {
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

    void Active(GameObject gameObject, bool state) {
        gameObject.SetActive(state);
    }

    void InteractableState(bool state) {
        FindAnyObjectByType<GameManager>().interactionEnabled = state;
    }

    void EndGame() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #elif UNITY_STANDALONE 
        Application.Quit();
        #endif
    }

    void ChangeHotspot(Interactable interactable, bool state) {
        interactable.canInteract = state;
    }

    void AddInventoryObject(InventoryObject inventoryObject) {
        FindAnyObjectByType<InventoryManager>().AddItem(inventoryObject);
    }

    void RemoveInventoryObject(InventoryObject inventoryObject) {
        FindAnyObjectByType<InventoryManager>().RemoveItem(inventoryObject);
    }

    bool CheckCurrentInventory(InventoryObject inventoryObject, ActionList actionListToSkipTo, int skipOnTrue) {
        if (inventoryObject == FindAnyObjectByType<InventoryManager>().GetSelectedItem()) {
            if (skipOnTrue == 0) {
                actionListToSkipTo.RunActionlist();
                return true;
            } else {
                return false;
            }
        } else {
            if (skipOnTrue == 1) {
                actionListToSkipTo.RunActionlist();
                return true;
            } else {
                return false;
            }
        }
    }
    void FadeCamera(float fadeAmount, float fadeTime) {
        FindAnyObjectByType<TopLevelUIManager>().Fade(fadeAmount, fadeTime);
    }

    void FadeSprite(float fadeAmount, float fadeTime, SpriteRenderer spriteRenderer) {
        spriteRenderer.DOFade(fadeAmount, fadeTime);
    }

    void ChangeScene(int useID, int sceneID, string sceneName) {
        if (useID == 0) {
            SceneManager.LoadScene(sceneID);
        } else {
            SceneManager.LoadScene(sceneName);
        }
    }
    /*
    Actions
    - Send Message
    - change camera
    - save
    - load
    - play sound
    - play music
    - check variable
    - set variable
    */
}
