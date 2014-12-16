using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LookAtPlayer))]
public class LookAtPlayerEditor : Editor {

    public override void OnInspectorGUI()
    {
        LookAtPlayer obj = (LookAtPlayer)target;

        bool[] tmp = obj.lockedAxis;
        GUILayout.Label("Axises To lock");
        tmp[0] = EditorGUILayout.Toggle("X", tmp[0]);
        tmp[1] = EditorGUILayout.Toggle("Y", tmp[1]);
        tmp[2] = EditorGUILayout.Toggle("Z", tmp[2]);
        tmp[3] = EditorGUILayout.Toggle("Inverted", tmp[3]);
        obj.lockedAxis = tmp;

    }
}
