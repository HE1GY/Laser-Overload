using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridField))]
    public class GridFieldEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GridField gridField = (GridField) target;
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Clean Field",GUILayout.Height(50)))
            {
                gridField.Clean();
            }
        }
    }
}