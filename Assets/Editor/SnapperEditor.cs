using UnityEngine;
using System.Collections;
using UnityEditor;
using util;
[CustomEditor(typeof(Snapper))]
public class SnapperEditor : Editor {

   /* public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Snapper obj = (Snapper)target;

        obj._Update();
    }*/

    public void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseUp)
        {
            Snapper obj = (Snapper)target;

            obj._Update();
        }
    }
}
