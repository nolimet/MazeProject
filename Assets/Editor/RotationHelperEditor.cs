using UnityEngine;
using System.Collections;
using UnityEditor;
using gameData;

[CustomEditor(typeof(RotationHelper))]
public class RotationHelperEditor: Editor {

    private int scoreToAdd;
    public override void OnInspectorGUI()
    {
        RotationHelper obj = (RotationHelper)target;


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("X +90 Degrees"))
            obj.rotate(new Vector3(0, 90, 0));

        if (GUILayout.Button("X -90 Degrees"))
            obj.rotate(new Vector3(0, -90, 0));
        GUILayout.EndHorizontal() ;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Y +90 Degrees"))
            obj.rotate(new Vector3(0, 90, 0));

        if (GUILayout.Button("Y -90 Degrees"))
            obj.rotate(new Vector3(0, -90, 0));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Z +90 Degrees"))
            obj.rotate(new Vector3(0, 90, 0));

        if (GUILayout.Button("Z -90 Degrees"))
            obj.rotate(new Vector3(0, -90, 0));
        GUILayout.EndHorizontal();
            

    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
