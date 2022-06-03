using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridHolder))]
    public class GridHolderEditor : UnityEditor.Editor
    {
        private const int TurnStep=90;
        private int _selected;


        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GridHolder gridHolder = (GridHolder) target;

            DrawTurnButton(gridHolder);
        }

        private static void DrawTurnButton(GridHolder gridHolder)
        {
            GUI.backgroundColor = Color.blue;
            if (GUILayout.Button("Turn", GUILayout.Height(25),GUILayout.Height(25)))
            {
                gridHolder.StartRotation -= TurnStep;
            }
        }
    }
}