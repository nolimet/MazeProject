using UnityEngine;
using System.Collections;
using UnityEditor;
using gameData;
[CustomEditor(typeof(Stats))]
public class StatsEditor : Editor {

    public override void OnInspectorGUI()
    {
        Stats obj = (Stats)target;
        obj.hpScaling = makeSlider(obj.hpScaling,"HP Scaling: " ,1f, 2f);
        obj.health = EditorGUILayout.FloatField("Health", obj.health);
        GUILayout.Label("HP on lvl 10 : " + (Mathf.Round(obj.health * Mathf.Pow(obj.hpScaling,9))));


            
    }

    public float makeSlider(float value, string label, float min, float max)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        value = EditorGUI.Slider(rect, label, value, min, max);
        EditorGUILayout.Space();
        return value;
    }
}
