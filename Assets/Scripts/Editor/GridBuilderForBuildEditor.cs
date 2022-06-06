using System;
using Grid;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridBuilderForBuild))]
    public class GridBuilderForBuildEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            GridFieldEditor.DrawBuildButton();
        }
    }
}