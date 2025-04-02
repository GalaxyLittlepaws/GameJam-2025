using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionList))]
public class ActionListEditor : Editor {
    ActionList baseElement;
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
            EditorGUILayout.LabelField("Action " + i);
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
}
