using Grid;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridField))]
    public class GridFieldEditor:UnityEditor.Editor
    {
        private static GridField gridField;

        public static int Mode; 
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            gridField = (GridField) target;

            if (Application.isPlaying)
            {
                GUILayout.BeginHorizontal();
                GUI.backgroundColor = Color.green;
                
                    if (GUILayout.Button("Build Mode",GUILayout.Height(50)))
                    {
                        gridField.ChooseBuilder(typeof(GridBuilderForBuild));
                        Mode = 1;
                    }
                    GUI.backgroundColor = Color.blue;
                    if (GUILayout.Button("Game Mode",GUILayout.Height(50)))
                    {
                        gridField.ChooseBuilder(typeof(GridBuilderForGame));
                        Mode = 2;
                    }
                    GUILayout.EndHorizontal();
            }
        }

        public static void DrawBuildButton()
        {
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Build",GUILayout.Height(50)))
            {
                gridField.Build();
            }
        }
    }
}