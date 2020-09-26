using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ActionBar))]
public class ActionBarEditor : Editor
{
    //private bool showPosition;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        /*
        ActionBar actionBar = (ActionBar)target;

        showPosition = EditorGUILayout.Foldout(showPosition, "Keybinds", true);
        if (showPosition)
        {
            for(int i = 0; i < actionBar.GetActionbarSize(); i++)
            {
                actionBar.SetKeybind(i, (KeyCode)EditorGUILayout.EnumFlagsField("Slot " + i.ToString(), actionBar.GetKeybind(i)));
            }
        }
        */
    }
}
