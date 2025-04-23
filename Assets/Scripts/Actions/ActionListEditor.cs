#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ActionList))]
public class ActionListEditor : Editor {
    ActionList baseElement;
    string[] actionNameList = new string[] {"Wait", "Visibility", "Transform", "Set Active", "Set Hotspot", "Interactable State", "Animate", "End Game",
    "Add Inventory Object", "Remove Inventory Object", "Check Current Inventory Object", "Fade Camera", "Fade Sprite", "Change Scene", "Play Sound",
     "Finish Bear", "Check Finale", "Enable Colour"};
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        baseElement = (ActionList)target;
        baseElement.runOnStart = EditorGUILayout.Toggle("Run on start?", baseElement.runOnStart);
        if (Application.isPlaying) {
            if (GUILayout.Button("Run Actions")) {
                baseElement.RunActionlist();
            }
            EditorGUILayout.Space(10);
        }
        
            for (int i = 0; i < baseElement.actionList.Count; i++) {
                Action actionListElement = baseElement.actionList[i];
                EditorGUILayout.LabelField("Action " + i);
                EditorGUILayout.Space(10);
                actionListElement.index = EditorGUILayout.Popup("Action Type:" ,actionListElement.index, actionNameList);
                if (actionListElement.index == 0) {
                    actionListElement.waitTime = EditorGUILayout.FloatField("Wait Time:", actionListElement.waitTime);
                } else if (actionListElement.index == 1) {
                    SetVisibility(actionListElement);
                } else if (actionListElement.index == 2) {
                    Transform(actionListElement);
                } else if (actionListElement.index == 3) {
                    Active(actionListElement);
                } else if (actionListElement.index == 4) {
                    ChangeHotspot(actionListElement);
                } else if (actionListElement.index == 5) {
                    InteractableState(actionListElement);
                } else if (actionListElement.index == 6) {
                    Animate(actionListElement);
                } else if (actionListElement.index == 7) {
                    EndGame();
                } else if (actionListElement.index == 8) {
                    AddInventoryObject(actionListElement);
                } else if (actionListElement.index == 9) {
                    RemoveInventoryObject(actionListElement);
                } else if (actionListElement.index == 10) {
                    CheckCurrentInventoryObject(actionListElement);
                } else if (actionListElement.index == 11) {
                    FadeCamera(actionListElement);
                } else if (actionListElement.index == 12) {
                    FadeSprite(actionListElement);
                } else if (actionListElement.index == 13) {
                    ChangeScene(actionListElement);
                } else if (actionListElement.index == 14) {
                    PlayAudio(actionListElement);
                } else if (actionListElement.index == 15) {
                    EditorGUILayout.LabelField("Will set to true");
                } else if (actionListElement.index == 16) {
                    CheckFinish(actionListElement);
                } else if (actionListElement.index == 17) {
                    EnableColour(actionListElement);
                }
                EditorGUILayout.Space(10);
                EndAction(i);
                EditorGUILayout.Space(10);
            }        
        if (GUILayout.Button("Add New Action")) {
            baseElement.actionList.Add(new Action());
        }
        if (!Application.isPlaying)
            EditorSceneManager.MarkAllScenesDirty();

    }
    void EndAction(int i) {
        EditorGUILayout.LabelField("Comment: ");
        baseElement.actionList[i].comment = EditorGUILayout.TextField(baseElement.actionList[i].comment);
        EditorGUILayout.BeginHorizontal();
        if (i == 0) {
            if (GUILayout.Button("Move Down")) {
                Action ovverideAction = baseElement.actionList[i+1];
                baseElement.actionList[i+1] = baseElement.actionList[i];
                baseElement.actionList[i] = ovverideAction;
            }
            if (GUILayout.Button("Insert Action")) {
                baseElement.actionList.Insert(i + 1, new Action());
            }
        } else if (i == baseElement.actionList.Count-1) {
            if (GUILayout.Button("Move Up")) {
                Action ovverideAction = baseElement.actionList[i-1];
                baseElement.actionList[i-1] = baseElement.actionList[i];
                baseElement.actionList[i] = ovverideAction;
            }
        } else {
            if (GUILayout.Button("Move Down")) {
                Action ovverideAction = baseElement.actionList[i+1];
                baseElement.actionList[i+1] = baseElement.actionList[i];
                baseElement.actionList[i] = ovverideAction;
            }
            if (GUILayout.Button("Move Up")) {
                Action ovverideAction = baseElement.actionList[i-1];
                baseElement.actionList[i-1] = baseElement.actionList[i];
                baseElement.actionList[i] = ovverideAction;
            }
            if (GUILayout.Button("Insert Action")) {
                baseElement.actionList.Insert(i + 1, new Action());
            }
        }
        if (GUILayout.Button("Delete")) {
            baseElement.actionList.RemoveAt(i);
        }
        EditorGUILayout.EndHorizontal();
    }

    void SetVisibility(Action action) {
        action.visiRenderer = (SpriteRenderer)EditorGUILayout.ObjectField("Sprite Renderer:", action.visiRenderer, typeof(SpriteRenderer), true);
        action.visiState = EditorGUILayout.Toggle("State:", action.visiState);
    }

    string[] animateOptions = new string[] {"Trigger", "Int", "Bool"};
    void Animate(Action action) {
        action.animType = EditorGUILayout.Popup("Animation trigger type:", action.animType, animateOptions);
        action.animAnimator = (Animator)EditorGUILayout.ObjectField("Animator:", action.animAnimator, typeof(Animator), true);
        action.animTrigger = EditorGUILayout.TextField("Trigger Name:", action.animTrigger);
        if (action.animType == 1) {
            action.animInt = EditorGUILayout.IntField("Value to set:", action.animInt);
        } if (action.animType == 2) {
            action.animBool = EditorGUILayout.Toggle("Value to set:", action.animBool);
        }
    }
    string[] transformOptions = new string[] {"Translate", "Rotate", "Scale"};
    void Transform(Action action) {
        action.transType = EditorGUILayout.Popup("Transform Type:", action.transType, transformOptions);
        action.transObject = (GameObject)EditorGUILayout.ObjectField("Transform Type:", action.transObject, typeof(GameObject), true);
        action.transTime = EditorGUILayout.FloatField("Time to transform:", action.transTime);
        action.waitForTransform = EditorGUILayout.Toggle("Wait for transform to complete?", action.waitForTransform);
        action.transNew = EditorGUILayout.Vector3Field("New Transform:", action.transNew);
    }

    void Active(Action action) {
        action.actObject = (GameObject)EditorGUILayout.ObjectField("Object to set:", action.actObject, typeof(GameObject), true);
        action.actState = EditorGUILayout.Toggle("State to set:", action.actState);
    }

    void InteractableState(Action action) {
        EditorGUILayout.LabelField("NOTE- This will affect GLOBAL INTERACTION, not a specific hotspot!");
        action.intState = EditorGUILayout.Toggle("Interaction State:", action.intState);
    }

    void EndGame() {
        EditorGUILayout.LabelField("Game will quit after this action is run."); 
    }

    void ChangeHotspot(Action action) {
        action.hotInteract = (Interactable)EditorGUILayout.ObjectField("Hotspot to set:", action.hotInteract, typeof(Interactable), true);
        action.hotState = EditorGUILayout.Toggle("State to set:", action.hotState);
    }

    void AddInventoryObject(Action action) {
        action.addInvObj = (InventoryObject)EditorGUILayout.ObjectField("Object to add:", action.addInvObj, typeof(InventoryObject), false);
    }
    void RemoveInventoryObject(Action action) {
        action.remInvObj = (InventoryObject)EditorGUILayout.ObjectField("Object to remove:", action.remInvObj, typeof(InventoryObject), false);
    }
    string[] invCheckTrue = new string[] {"Run Actionlist if True", "Run Actionlist if False"};
    void CheckCurrentInventoryObject(Action action) {
        action.checkInvObj = (InventoryObject)EditorGUILayout.ObjectField("Object to check:", action.checkInvObj, typeof(InventoryObject), false);
        action.checkSkipTrue = EditorGUILayout.Popup(action.checkSkipTrue, invCheckTrue);
        action.checkSkipTo = (ActionList)EditorGUILayout.ObjectField("Actionlist to run:", action.checkSkipTo, typeof(ActionList), true);
    }
    void FadeCamera(Action action) {
        action.camFadeAmount = EditorGUILayout.Slider("Fade Amount:", action.camFadeAmount, 0, 1);
        action.camFadeTime = EditorGUILayout.FloatField("Fade Time:", action.camFadeTime);
    }
    void FadeSprite(Action action) {
        action.spriteFade = (SpriteRenderer)EditorGUILayout.ObjectField("Sprite to fade:", action.spriteFade, typeof(SpriteRenderer), true);
        action.spriteFadeAmount = EditorGUILayout.Slider("Fade Amount:", action.spriteFadeAmount, 0, 1);
        action.spriteFadeTime = EditorGUILayout.FloatField("Fade Time:", action.spriteFadeTime);
    }
    string[] sceneStates = new string[] {"Scene ID", "Scene Name"};
    void ChangeScene(Action action) {
        action.useID = EditorGUILayout.Popup(action.useID, sceneStates);
        if (action.useID == 0)
            action.sceneID = EditorGUILayout.IntField("SceneID:", action.sceneID);
        else
            action.sceneName = EditorGUILayout.TextField("Scene Name:", action.sceneName);
    }
    void PlayAudio(Action action) {
        action.audioManager = (AudioManager)EditorGUILayout.ObjectField("Audio To Play:", action.audioManager, typeof(AudioManager), true);
    }
    void CheckFinish(Action action){
        action.listToPlay = (ActionList)EditorGUILayout.ObjectField("List to play:", action.listToPlay, typeof(ActionList), true);
    }
    string[] colourString = new string[] {"Red", "Yellow", "Blue", "Green"};
    void EnableColour(Action action) {
        action.colourToUnlock = EditorGUILayout.Popup(action.colourToUnlock, colourString);
    }
}
#endif