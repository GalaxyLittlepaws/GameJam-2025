using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionList))]
public class ActionListEditor : Editor {
    ActionList baseElement;
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        baseElement = (ActionList)target;
        for (int i = 0; i < baseElement.actionList.Count; i++) {
            EditorGUILayout.LabelField("Action " + i);
            EndAction(i);
            EditorGUILayout.Space(10);
            if (GUILayout.Button("Add New Action")) {
                baseElement.actionList.Add(new Action());
            }
        }        

    }
    void EndAction(int i) {
        EditorGUILayout.LabelField("Comment: ");
            EditorGUILayout.TextField("");
            EditorGUILayout.BeginHorizontal();
            if (i == 0) {
                if (GUILayout.Button("Move Down")) {
                    
                }
                if (GUILayout.Button("Insert Action")) {
                    baseElement.actionList.Insert(i + 1, new Action());
                }
            } else if (i == baseElement.actionList.Count-1) {
                if (GUILayout.Button("Move Up")) {
                    
                }
            } else {
                if (GUILayout.Button("Move Down")) {
                    
                }
                if (GUILayout.Button("Move Up")) {
                    
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
