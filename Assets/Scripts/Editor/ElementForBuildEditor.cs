using Grid;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ElementForBuild))]
    public class ElementForBuildEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            ElementForBuild elementForBuild = (ElementForBuild) target;

            GUILayout.BeginVertical();
            
            GUI.backgroundColor=Color.yellow;
            if(GUILayout.Button("Laser",GUILayout.Height(50)))
            {
                elementForBuild.ElementType=ElementType.Laser;
            }
            GUI.backgroundColor=Color.blue;
            if(GUILayout.Button("Platform",GUILayout.Height(50)))
            {
                elementForBuild.ElementType=ElementType.Platform;
            }
            GUI.backgroundColor=Color.red;
            if(GUILayout.Button("Battery",GUILayout.Height(50)))
            {
                elementForBuild.ElementType=ElementType.Battery;
            }
            GUI.backgroundColor=Color.cyan;
            if(GUILayout.Button("Laser[3]",GUILayout.Height(50)))
            {
                elementForBuild.ElementType=ElementType.Laser3;
            }
            GUI.backgroundColor=Color.green;
            if(GUILayout.Button("Empty",GUILayout.Height(50)))
            {
                elementForBuild.ElementType=ElementType.Empty;
            }
            
            
            GUILayout.Space(20);
            GUI.backgroundColor=Color.black;
            if(GUILayout.Button("Turn",GUILayout.Height(50)))
            {
                elementForBuild.Turn();
            }
            
            GUILayout.EndVertical();
            
            
            
        }
    }
}