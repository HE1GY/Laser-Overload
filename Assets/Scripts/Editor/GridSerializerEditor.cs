using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(GridSerializer))]
    public class GridSerializerEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GUILayout.BeginHorizontal();
            GridSerializer gridSerializer = (GridSerializer) target;
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Save Grid",GUILayout.Height(50)))
            {
                gridSerializer.Save();
            }
            
            GUI.backgroundColor = Color.blue; 
            if(GUILayout.Button("Load Grid",GUILayout.Height(50)))
            {
                gridSerializer.Load();
            }
            GUILayout.EndHorizontal();
        }
    }
}