using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BasePanel) ,true)] // relate to script
public class BasePanelEditorGUI : Editor
{
    private SerializedObject basePanel;
     //  public field
    public SerializedProperty showOnStart;
    public SerializedProperty switchType;
    public SerializedProperty fadeInTime;
    public SerializedProperty fadeOutTime;
    public SerializedProperty horizontalStartPointX;
    public SerializedProperty horizontalEndPointX;
    public SerializedProperty verticalStartPointY;
    public SerializedProperty verticalEndPointY;

    void OnEnable()
    {
        basePanel = new SerializedObject(target);
        // All public variables
        switchType = basePanel.FindProperty("switchType");
        showOnStart = basePanel.FindProperty("showOnStart");
        fadeInTime = basePanel.FindProperty("fadeInTime");
        fadeOutTime = basePanel.FindProperty("fadeOutTime");
        horizontalStartPointX = basePanel.FindProperty("horizontalStartPointX");
        horizontalEndPointX = basePanel.FindProperty("horizontalEndPointX");
        verticalStartPointY = basePanel.FindProperty("verticalStartPointY");
        verticalEndPointY = basePanel.FindProperty("verticalEndPointY");
    }

    public override void OnInspectorGUI()
    {
        basePanel.Update();//  refresh  InspectorGUI

        //  base  public field
        EditorGUILayout.PropertyField(showOnStart);
        EditorGUILayout.PropertyField(switchType);
        EditorGUILayout.PropertyField(fadeInTime);
        EditorGUILayout.PropertyField(fadeOutTime);

        if (switchType.enumValueIndex == 0) //  center
        {
        }
        else if (switchType.enumValueIndex == 1) // horizontal
        {
            EditorGUILayout.PropertyField(horizontalStartPointX);
            EditorGUILayout.PropertyField(horizontalEndPointX);
        }
        else if (switchType.enumValueIndex == 2) //  vertical
        {
            EditorGUILayout.PropertyField(verticalStartPointY);
            EditorGUILayout.PropertyField(verticalEndPointY);
        }
        basePanel.ApplyModifiedProperties();//  Apply 
    }



}
