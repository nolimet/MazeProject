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
        obj.maxHealth = EditorGUILayout.FloatField("Health", obj.maxHealth);
        GUILayout.Label("HP on lvl 10 : " + (Mathf.Round(obj.maxHealth * Mathf.Pow(obj.hpScaling,9))));

        EditorGUILayout.Space();

        DrawMicroData(obj.weaknesses, "weakness");
        DrawMicroData(obj.resistances, "resistances");

            
    }

    public float makeSlider(float value, string label, float min, float max)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        value = EditorGUI.Slider(rect, label, value, min, max);
        EditorGUILayout.Space();
        return value;
    }

    void DrawMicroData(Stats.microData mirco, string label)
    {
        mirco.weak = (Stats.DMGTypes)EditorGUILayout.EnumPopup("weak " + label, mirco.weak);
        mirco.mid = (Stats.DMGTypes)EditorGUILayout.EnumPopup("mid " + label, mirco.mid);
        mirco.strong = (Stats.DMGTypes)EditorGUILayout.EnumPopup("strong " + label, mirco.strong);
       EditorGUILayout.Space();
    }
}
