using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(MazeGenerator))]
public class MazeGenEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MazeGenerator obj = (MazeGenerator)target;
        if (GUILayout.Button("Bake Maze"))
            obj.BuildMaze();
        if (GUILayout.Button("Clear Maze"))
            obj.cleanUp();

    }	
}
