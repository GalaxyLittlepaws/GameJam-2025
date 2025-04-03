using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionList))]
public class ActionListEditor : Editor {
    ActionList baseElement;
    string[] actionNameList = new string[] {"Wait", "Visibility", "Transform", "Set Active", "Set Hotspot", "Interactable State", "Animate", "End Game"};
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        baseElement = (ActionList)target;
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
            }
            EditorGUILayout.Space(10);
            EndAction(i);
            EditorGUILayout.Space(10);
            
        }
        if (GUILayout.Button("Add New Action")) {
            baseElement.actionList.Add(new Action());
        }

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

    void Transform(Action action) {
       
    }

    void Active(Action action) {
    }

    void InteractableState(Action action) {
    }

    void EndGame() {
        EditorGUILayout.LabelField("Game will quit after this action is run."); 
    }

    void ChangeHotspot(Action action) {
    }
}
